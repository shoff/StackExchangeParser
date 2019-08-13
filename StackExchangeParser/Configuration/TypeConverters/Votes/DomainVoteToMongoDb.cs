namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;

    public class DomainVoteToMongoDb : ITypeConverter<Domain.Models.Vote, MongoDb.Entities.Vote>
    {
        public MongoDb.Entities.Vote Convert(Domain.Models.Vote source, MongoDb.Entities.Vote destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.Vote
            {
                CreationDate = source.CreationDate,
                Id = source.Id,
                PostId = source.PostId,
                UserId = source.UserId,
                VoteTypeId = source.VoteTypeId
            };
            return destination;
        }
    }
}
