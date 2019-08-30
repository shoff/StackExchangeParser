namespace StackExchangeParser.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Data;
    using Domain.Models;
    using Microsoft.Extensions.Logging;

    public class XLinqRepository : IXLinqRepository
    {
        private readonly ILogger<XLinqRepository> logger;
        private readonly IBadgeParser badgeParser;
        private readonly ICommentParser commentParser;
        private readonly IPostHistoryParser postHistoryParser;
        private readonly IPostParser postParser;
        private readonly ITagParser tagParser;
        private readonly IUserParser userParser;
        private readonly IVoteParser voteParser;

        public XLinqRepository(
            ILogger<XLinqRepository> logger,
            IBadgeParser badgeParser,
            ICommentParser commentParser,
            IPostHistoryParser postHistoryParser,
            IPostParser postParser,
            ITagParser tagParser,
            IUserParser userParser,
            IVoteParser voteParser)
        {
            this.logger = logger;
            this.badgeParser = badgeParser;
            this.commentParser = commentParser;
            this.postHistoryParser = postHistoryParser;
            this.postParser = postParser;
            this.tagParser = tagParser;
            this.userParser = userParser;
            this.voteParser = voteParser;
        }

        public ICollection<IPost> Posts()
        {
            try
            {
                var posts = this.postParser.Parse();
                this.logger.LogInformation($"Found {posts.Count} posts");
                return posts;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<IUser> Users()
        {
            try
            {
                var users = this.userParser.Parse();
                this.logger.LogInformation($"Found {users.Count} users");
                return users;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<IComment> Comments()
        {
            try
            {
                var comments = this.commentParser.Parse();
                this.logger.LogInformation($"Found {comments.Count} comments");
                return comments;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<IVote> Votes()
        {
            try
            {
                var votes = this.voteParser.Parse();
                this.logger.LogInformation($"Found {votes.Count} votes");
                return votes;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<ITag> Tags()
        {
            try
            {
                var tags = this.tagParser.Parse();
                this.logger.LogInformation($"Found {tags.Count} tags");
                return tags;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<IBadge> Badges()
        {
            try
            {
                var badges = this.badgeParser.Parse();
                this.logger.LogInformation($"Found {badges.Count} badges");
                return badges;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }
        public ICollection<IPostHistory> PostHistories()
        {
            try
            {
                var postHistories = this.postHistoryParser.Parse();
                this.logger.LogInformation($"Found {postHistories.Count} post histories");
                return postHistories;
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);
                throw;
            }
        }

        public Task<ICollection<IPost>> PostsAsync(CancellationToken cancellationToken = default)
        {
            return this.postParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<IUser>> UsersAsync(CancellationToken cancellationToken)
        {
            return this.userParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<IComment>> CommentsAsync(CancellationToken cancellationToken = default)
        {
            return this.commentParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<ITag>> TagsAsync(CancellationToken cancellationToken = default)
        {
            return this.tagParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<IBadge>> BadgesAsync(CancellationToken cancellationToken = default)
        {
            return this.badgeParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<IPostHistory>> PostHistoriesAsync(CancellationToken cancellationToken = default)
        {
            return this.postHistoryParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<IVote>> VotesAsync(CancellationToken cancellationToken = default)
        {
            return this.voteParser.ParseAsync(cancellationToken);
        }
    }
}