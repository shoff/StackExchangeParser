namespace StackExchangeParser.Elasticsearch
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain;
    using Domain.Configuration;
    using Domain.Models;
    using global::Elasticsearch.Net;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Nest;
    using Zatoichi.Common.Infrastructure.Extensions;

    public class SearchService : IStackExchangeRepository
    {
        private readonly ILogger<SearchService> logger;
        private readonly IMapper mapper;
        private readonly IClientManager clientManager;
        private readonly string projectName;

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

        public bool BulkIndex { get; set; } = true;

        public ICollection<IPost> Posts()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IUser> Users()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IComment> Comments()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ITag> Tags()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IBadge> Badges()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IPostHistory> PostHistories()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IVote> Votes()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddUsersAsync(ICollection<IUser> users, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_user", e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticUser>(users.AsQueryable());

            if (this.BulkIndex)
            {
                var indexResponse =
                    await this.clientManager.LowLevelClient.BulkAsync<StringResponse>
                            ($"{this.projectName}_users", PostData.Serializable(us), ctx: cancellationToken)
                        .ConfigureAwait(false);
                this.logger.LogInformation($"Bulk insert succeeded: {indexResponse.Success}");
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddPostsAsync(ICollection<IPost> posts, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_posts", e => e.Map(m => m.AutoMap()));
            var ps = this.mapper.ProjectTo<ElasticPost>(posts.AsQueryable());

            if (this.BulkIndex)
            {
                var indexResponse =
                    await this.clientManager.LowLevelClient.BulkAsync<StringResponse>($"{this.projectName}_posts",
                            PostData.Serializable(ps), ctx: cancellationToken)
                        .ConfigureAwait(false);
                this.logger.LogInformation($"Bulk insert succeeded: {indexResponse.Success}");
            }
            else
            {
                this.Insert(ps);
            }
        }

        public async Task AddCommentsAsync(ICollection<IComment> comments, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_comments", e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticComment>(comments.AsQueryable());

            if (this.BulkIndex)
            {
                var indexResponse =
                    await this.clientManager.LowLevelClient.BulkAsync<StringResponse>($"{this.projectName}_comments",
                            PostData.Serializable(us), ctx: cancellationToken)
                        .ConfigureAwait(false);
                this.logger.LogInformation($"Bulk insert succeeded: {indexResponse.Success}");
            }
            else
            {
                this.Insert(us);
            }
        }


        public async Task AddTagsAsync(ICollection<ITag> tags, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_tags", e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticTag>(tags.AsQueryable());
            if (this.BulkIndex)
            {
                var indexResponse =
                  await this.clientManager.LowLevelClient.BulkAsync<StringResponse>($"{this.projectName}_tags", PostData.Serializable(us), ctx: cancellationToken)
                      .ConfigureAwait(false);
                this.logger.LogInformation($"Bulk insert succeeded: {indexResponse.Success}");
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
                var indexResponse =
                    await this.clientManager.LowLevelClient.BulkAsync<StringResponse>($"{this.projectName}_votes",
                            PostData.Serializable(us), ctx: cancellationToken)
                        .ConfigureAwait(false);
                this.logger.LogInformation($"Bulk insert succeeded: {indexResponse.Success}");
            }
            else
            {
                this.Insert(us);
            }
        }

        public async Task AddBadgesAsync(ICollection<IBadge> badges, CancellationToken cancellationToken)
        {
            await this.clientManager.EnsureNewIndexIsCreatedAsync($"{this.projectName}_badges", e => e.Map(m => m.AutoMap()));
            var us = this.mapper.ProjectTo<ElasticBadge>(badges.AsQueryable());

            if (this.BulkIndex)
            {
                await this.BulkInsert(us, cancellationToken);
            }
            else
            {
                this.Insert(us);
            }
        }

        private async Task BulkInsert<T>(IEnumerable<T> t, CancellationToken cancellationToken)
            where T : class, IIndexable
        {
            var index = string.Format(t.First().IndexName, this.projectName);
            var response = await this.clientManager.LowLevelClient.BulkAsync<StringResponse>(index, PostData.Serializable(t.AsQueryable()), ctx: cancellationToken)
                    .ConfigureAwait(false);
            this.logger.LogInformation($"Bulk insert succeeded: {response.Success}");

        }

        private void Insert<T>(IEnumerable<T> t)
            where T : class, IIndexable
        {
            var indexables = t as T[] ?? t.ToArray();
            indexables.Each(u =>
            {
                var response = this.clientManager.HighLevelClient.Index(indexables,
                    i => i.Index(string.Format(u.IndexName, this.projectName)));
                this.logger.LogInformation($"{response.Result}");
            });
        }
    }
}