namespace StackExchangeParser.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Domain;
    using Domain.Models;
    using EF;

    public class EFRepository : IStackExchangeRepository, IEFRepository
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

        public ICollection<Post> Posts()
        {
            return this.mapper.ProjectTo<Domain.Models.Post>(this.dbContext.Posts).ToList();
        }

        public ICollection<User> Users()
        {
            return this.mapper.ProjectTo<Domain.Models.User>(this.dbContext.Users).ToList();
        }

        public ICollection<Comment> Comments()
        {
            return this.mapper.ProjectTo<Domain.Models.Comment>(this.dbContext.Comments).ToList();
        }

        public ICollection<Tag> Tags()
        {
            return this.mapper.ProjectTo<Domain.Models.Tag>(this.dbContext.Tags).ToList();
        }

        public ICollection<Badge> Badges()
        {
            return this.mapper.ProjectTo<Domain.Models.Badge>(this.dbContext.Badges).ToList();
        }

        public ICollection<PostHistory> PostHistories()
        {
            return this.mapper.ProjectTo<Domain.Models.PostHistory>(this.dbContext.PostHistories).ToList();
        }

        public ICollection<Vote> Votes()
        {
            return this.mapper.ProjectTo<Domain.Models.Vote>(this.dbContext.Votes).ToList();
        }
    }
}