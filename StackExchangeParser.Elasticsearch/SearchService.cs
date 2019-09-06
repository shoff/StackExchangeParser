namespace StackExchangeParser.Elasticsearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Configuration;
    using Domain.Extensions;
    using Domain.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Nest;
    using Newtonsoft.Json;
    using Zatoichi.Common.Infrastructure.Extensions;
    using Bytes = Domain.Extensions.Bytes;

    public class SearchService : ISearchService
    {
        private static readonly Random random = new Random((int)DateTime.UtcNow.Ticks);

        private static readonly Dictionary<int, int> bulkCount = new Dictionary<int, int>();

        private readonly IClientManager clientManager;
        private readonly ILogger<SearchService> logger;
        private readonly IMapper mapper;
        private readonly string projectName;
        private int errorCount;

        public SearchService(
            IOptions<StackExchangeData> options,
            ILogger<SearchService> logger,
            IMapper mapper,
            IClientManager clientManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.clientManager = clientManager;
            this.projectName = options.Value.ProjectName.ToLowerInvariant();
#if DEBUG
            this.logger.LogDebug($"{this.clientManager.HighLevelClient.Cluster.Health()}");
#endif
        }

        public async Task AddUsersAsync(ICollection<IUser> users, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_users",
                e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticUser>(users.AsQueryable());

            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(us, cancellationToken)
                    .ConfigureAwait(false);

                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_users");
                }
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddPostsAsync(ICollection<IPost> posts, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_posts",
                e => e.Map(m => m.AutoMap()));
            var ps = this.mapper.ProjectTo<ElasticPost>(posts.AsQueryable());

            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(ps, cancellationToken).ConfigureAwait(false);
                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_posts");
                }
            }
            else
            {
                this.Insert(ps);
            }
        }

        public async Task AddCommentsAsync(ICollection<IComment> comments, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_comments",
                e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticComment>(comments.AsQueryable());

            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(us, cancellationToken).ConfigureAwait(false);
                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_comments");
                }
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddTagsAsync(ICollection<ITag> tags, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_tags",
                e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticTag>(tags.AsQueryable());
            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(us, cancellationToken).ConfigureAwait(false);
                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_tags");
                }
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddVotesAsync(ICollection<IVote> votes, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_votes",
                e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticVote>(votes.AsQueryable());

            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(us, cancellationToken).ConfigureAwait(false);
                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_votes");
                }
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddBadgesAsync(ICollection<IBadge> badges, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_badges",
                e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticBadge>(badges.AsQueryable());

            if (this.BulkIndex)
            {
                bool completedWithoutErrors = await this.BulkInsert(us, cancellationToken).ConfigureAwait(false);
                if (!completedWithoutErrors)
                {
                    this.HandleFailedChunks($"{this.projectName}_badges");
                }
            }
            else
            {
                this.Insert(us);
            }
        }

        private async Task<bool> BulkInsert<T>(IEnumerable<T> t, CancellationToken cancellationToken)
            where T : class, IIndexable
        {
            var indexables = t as T[] ?? t.ToArray();
            var index = string.Format(indexables.First().IndexName, this.projectName);
            var chunks = this.CreateChunks(indexables);
            
            foreach (var chunk in chunks)
            {
                var response = await this.SendToIndex(cancellationToken, index, chunk);

                if (response.OriginalException != null || !response.IsValid)
                {
                    Interlocked.Increment(ref this.errorCount);
                    this.TotalFailures++;
                    this.FinalFailureCount++;
                    this.logger.LogError(
                        $"Error occured while indexing on chunk number {chunk.Key}, current error count: {this.errorCount}");

                    if (response.OriginalException != null)
                    {
                        this.logger.LogError(response.OriginalException.Message, response.OriginalException);
                    }

                    this.FailedChunks.EnqueueChunk(chunk.Value);

                    if (this.errorCount >= this.ErrorCountBreakPoint)
                    {
                        // increment the document difference
                        this.DocumentThresholdAdjustment += 100;
                        this.errorCount = 0;
                    }
                }
                else
                {
                    this.logger.LogInformation(
                        $"Bulk insert of {this.MaximumNumberOfDocumentsPerInsert} documents succeeded: {response.IsValid}");
                }
            }

            return this.FailedChunks.Count == 0;
        }

        private void HandleFailedChunks(string index)
        {
            // process failed indexes. 
            // TODO validate EACH insert.
            if (!this.RetryFailedChunks && !this.SaveFailedDocumentsToDisk)
            {
                this.logger.LogWarning(
                    "Somehow, we entered the HandleFailedChunks method when retrying failed chunks is disabled");
                return;
            }

            if (!Directory.Exists(this.FailedDirectory) && this.SaveFailedDocumentsToDisk)
            {
                Directory.CreateDirectory(this.FailedDirectory);
            }

            while (this.FailedChunks.TryDequeue(out var failedChunk))
            {
                var chunkId = Guid.NewGuid();

                try
                {
                    if (this.SaveFailedDocumentsToDisk)
                    {
                        File.WriteAllText($"{this.FailedDirectory}/{chunkId}.json",
                            JsonConvert.SerializeObject(failedChunk));
                    }

                    if (this.RetryFailedChunks)
                    {
                        var response = this.clientManager.HighLevelClient.Index(failedChunk,
                            i => i.Index(string.Format(index, this.projectName)));

                        if (response.OriginalException != null)
                        {
                            this.logger.LogError(response.OriginalException.Message, response.OriginalException);
                        }
                        else
                        {
                            this.FinalFailureCount--;
                            this.logger.LogInformation("Completed indexing failed chunk");
                        }
                    }
                }
                catch (Exception e)
                {
                    this.logger.LogError($"Unrecoverable handling a failed chunk {chunkId}.");
                    this.logger.LogError(e, e.Message);
                }
            }
        }

        private async Task<BulkResponse> SendToIndex<T>(CancellationToken cancellationToken, string index,
            KeyValuePair<int, T[]> chunk)
            where T : class, IIndexable
        {
            var response = await this.clientManager.HighLevelClient.BulkAsync(b => b.Index(index)
                .IndexMany(chunk.Value), cancellationToken);

            return response;
        }

        private Dictionary<int, T[]> CreateChunks<T>(T[] indexables) where T : class, IIndexable
        {
            var chunks = new Dictionary<int, T[]>();

            this.MaximumNumberOfDocumentsPerInsert = this.CalculateMaxDocuments(indexables) - this.DocumentThresholdAdjustment;
            if (this.MaximumNumberOfDocumentsPerInsert < this.DocumentThresholdAdjustment)
            {
                this.logger.LogWarning(
                    $"Bulk inserts are limited to {this.DocumentThresholdAdjustment} documents per insert. Please ensure the health of the cluster.");
                this.MaximumNumberOfDocumentsPerInsert = this.DocumentThresholdAdjustment;
            }

            if (indexables.Length <= this.MaximumNumberOfDocumentsPerInsert)
            {
                return new Dictionary<int, T[]> { { 1, indexables } };
            }

            var splitCount = (double)indexables.Length / this.MaximumNumberOfDocumentsPerInsert;
            var chunkCount = Convert.ToInt32(Math.Truncate(splitCount)) + 1;

            for (var i = 0; i < chunkCount; i++)
            {
                chunks.Add(i,
                    indexables.Skip(i * this.MaximumNumberOfDocumentsPerInsert)
                        .Take(this.MaximumNumberOfDocumentsPerInsert).ToArray());
            }

            return chunks;
        }

        private int CalculateMaxDocuments<T>(T[] indexables) where T : class, IIndexable
        {
            if (indexables.Length == 0)
            {
                return 0;
            }

            var averageSampleCount = (ushort)(indexables.Length < 20 ? indexables.Length : 20);
            var megaBytes = new Bytes.MegaByte[averageSampleCount];
            var usedIds = new int[averageSampleCount];

            usedIds[0] = 0;
            megaBytes[0] = JsonConvert.SerializeObject(indexables[0]).Size();

            for (ushort i = 1; i < averageSampleCount; i++)
            {
                if (averageSampleCount <= 20)
                {
                    megaBytes[i] = JsonConvert.SerializeObject(indexables[i]).Size();
                }
                else
                {
                    var itemIndex = 0;

                    while (Array.IndexOf(usedIds, itemIndex) > -1)
                    {
                        itemIndex = random.Next(1, averageSampleCount);
                    }

                    megaBytes[i] = JsonConvert.SerializeObject(indexables[itemIndex]).Size();
                }
            }

            var averageMegs = megaBytes.Map(m => m.Count).AsQueryable().Average();
            var averageKilos = megaBytes.Map(m => m.KiloBytes).AsQueryable().Average();

            this.logger.LogInformation($"Average document size (in Mb: {averageMegs}):(in Kb: {averageKilos})");
            if (averageMegs >= 16)
            {
                return bulkCount[16];
            }

            return bulkCount[Convert.ToInt32(Math.Truncate(averageMegs))];
        }

        private void Insert<T>(IEnumerable<T> t)
            where T : class, IIndexable
        {
            var indexables = t as T[] ?? t.ToArray();
            var count = indexables.Length;
            var current = 0;
            Parallel.ForEach(indexables, u =>
            {
                Interlocked.Increment(ref current);
                var response = this.clientManager.HighLevelClient.Index(u,
                    i => i.Index(string.Format(u.IndexName, this.projectName)));

                if (response.OriginalException != null)
                {
                    this.logger.LogError(response.OriginalException.Message, response.OriginalException);
                }
                else
                {
                    this.logger.LogInformation($"Completed index item {current} or {count} result: {response.Result}");
                }
            });
        }

        public int TotalFailures { get; private set; }

        public int FinalFailureCount { get; set; }

        public bool BulkIndex { get; set; } = true;

        public Queue<object> FailedChunks { get; } = new Queue<object>();

        // at this point we will reset the error count and lower the max docs per insert count.
        public int ErrorCountBreakPoint { get; set; } = 100;

        // the number to decrease documents in the event of error count breaching
        // we will get the difference each chunk as the actual count and increment this when breaching error threshold
        public int DocumentThresholdAdjustment { get; set; }

        public bool RetryFailedChunks { get; set; } = true;

        public static int ChunkIterationSize { get; set; } = 100;

        public static int MaximumChunkSize { get; set; } = 5000;

        public bool SaveFailedDocumentsToDisk { get; set; } = true;
        public string FailedDirectory { get; set; } = "Failed";
        public int MaximumNumberOfDocumentsPerInsert { get; private set; }

        static SearchService()
        {
            bulkCount.Add(0, MaximumChunkSize);
            var size = MaximumChunkSize;
            // max document size is 16 Mb
            for (int i = 1; i < 17; i++)
            {
                size = size - ChunkIterationSize;
                bulkCount.Add(i, size);
            }
        }
    }
}