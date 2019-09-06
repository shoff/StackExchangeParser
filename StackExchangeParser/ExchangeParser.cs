namespace StackExchangeParser
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Elasticsearch;
    using Elasticsearch.Models;
    using Infrastructure;
    using Microsoft.Extensions.Logging;

    public class ExchangeParser : IExchangeParser
    {
        private readonly ILogger<ExchangeParser> logger;
        private readonly ISearchService searchService;
        private readonly IXLinqRepository linqRepository;

        public ExchangeParser(
            ILogger<ExchangeParser> logger,
            ISearchService searchService,
            IXLinqRepository linqRepository)
        {
            this.logger = logger;
            this.searchService = searchService;

#if USE_ELASTIC
            ((SearchService)this.searchService).BulkIndex = true;
#endif
            this.linqRepository = linqRepository;
        }

        private static long elapsed;
        private static readonly Stopwatch stopwatch = new Stopwatch();

        public async Task ProcessDataAsync(CancellationToken cancellationToken = default)
        {
            var indexingData = new IndexingData();

            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml users.");
            var users = await this.linqRepository.UsersAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending users to store.");
            await this.searchService.AddUsersAsync(users, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();

            elapsed += stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml posts.");
            var posts = await this.linqRepository.PostsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending posts to store.");
            await this.searchService.AddPostsAsync(posts, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml comments.");
            var comments = await this.linqRepository.CommentsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending comments to store.");
            await this.searchService.AddCommentsAsync(comments, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml tags.");
            var tags = await this.linqRepository.TagsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending tags to store.");
            await this.searchService.AddTagsAsync(tags, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml votes.");
            var votes = await this.linqRepository.VotesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending votes to store.");
            await this.searchService.AddVotesAsync(votes, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            this.logger.LogInformation("Fetching and parsing xml badges.");
            var badges = await this.linqRepository.BadgesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending badges to store.");
            await this.searchService.AddBadgesAsync(badges, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();
            elapsed += stopwatch.ElapsedMilliseconds;


            this.logger.LogInformation("Sending indexing data to store.");


            indexingData.CreationDate = DateTime.UtcNow;
            indexingData.DocumentThresholdAdjustment = SearchService.ChunkIterationSize;
            indexingData.ErrorBreakpoint = this.searchService.ErrorCountBreakPoint;
            indexingData.MaximumChunkSize = SearchService.MaximumChunkSize;
            indexingData.RetryFailedChunks = this.searchService.RetryFailedChunks;
            indexingData.RunningTime = stopwatch.ElapsedMilliseconds;
            indexingData.TotalDocumentsIndexed =
                (badges.Count + votes.Count + tags.Count + comments.Count + posts.Count + users.Count) -
                this.searchService.FinalFailureCount;
            indexingData.TotalErrors = this.searchService.TotalFailures;
            indexingData.FinalFailureCount = this.searchService.FinalFailureCount;



        }
    }
}