namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Votes;

    public class StackExchangeVoteProfile : Profile
    {
        public StackExchangeVoteProfile()
        {
            this.CreateMap<Domain.Models.Vote, EF.Entities.Vote>().ConvertUsing<DomainVoteToEF>();
            this.CreateMap<Domain.Models.Vote, MongoDb.Entities.Vote>().ConvertUsing<DomainVoteToMongoDb>();
            this.CreateMap<EF.Entities.Vote, Domain.Models.Vote>().ConvertUsing<EFVoteToDomain>();
            this.CreateMap<MongoDb.Entities.Vote, Domain.Models.Vote>().ConvertUsing<MongoDbVoteToDomain>();
        }
    }
}