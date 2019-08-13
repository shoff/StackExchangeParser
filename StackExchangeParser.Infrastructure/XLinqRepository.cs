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

        public ICollection<Post> Posts()
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
        public ICollection<User> Users()
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
        public ICollection<Comment> Comments()
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
        public ICollection<Vote> Votes()
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
        public ICollection<Tag> Tags()
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
        public ICollection<Badge> Badges()
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
        public ICollection<PostHistory> PostHistories()
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

        public Task<ICollection<Post>> PostsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> UsersAsync(CancellationToken cancellationToken = default)
        {
            return this.userParser.ParseAsync(cancellationToken);
        }

        public Task<ICollection<Comment>> CommentsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Tag>> TagsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Badge>> BadgesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PostHistory>> PostHistoriesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Vote>> GetVotesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}