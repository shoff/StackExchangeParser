namespace StackExchangeParser.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain;
    using Domain.Models;
    using EF;

    public class EFRepository : IStackExchangeRepository
    {
        private readonly IMapper mapper;
        private readonly StackExchangeDbContext dbContext;

        public EFRepository(
            IMapper mapper,
            StackExchangeDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public ICollection<IPost> Posts()
        {
            return this.mapper.ProjectTo<Domain.Models.IPost>(this.dbContext.Posts).ToList();
        }

        public Task AddUsersAsync(ICollection<IUser> users, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task AddPostsAsync(ICollection<IPost> posts, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task AddCommentsAsync(ICollection<IComment> comments, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task AddTagsAsync(ICollection<ITag> tags, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task AddVotesAsync(ICollection<IVote> votes, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task AddBadgesAsync(ICollection<IBadge> badges, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IUser> Users()
        {
            return this.mapper.ProjectTo<Domain.Models.IUser>(this.dbContext.Users).ToList();
        }

        public ICollection<IComment> Comments()
        {
            return this.mapper.ProjectTo<Domain.Models.IComment>(this.dbContext.Comments).ToList();
        }

        public ICollection<ITag> Tags()
        {
            return this.mapper.ProjectTo<Domain.Models.ITag>(this.dbContext.Tags).ToList();
        }

        public ICollection<IBadge> Badges()
        {
            return this.mapper.ProjectTo<Domain.Models.IBadge>(this.dbContext.Badges).ToList();
        }

        public ICollection<IPostHistory> PostHistories()
        {
            return this.mapper.ProjectTo<Domain.Models.IPostHistory>(this.dbContext.PostHistories).ToList();
        }

        public ICollection<IVote> Votes()
        {
            return this.mapper.ProjectTo<Domain.Models.IVote>(this.dbContext.Votes).ToList();
        }
    }
}