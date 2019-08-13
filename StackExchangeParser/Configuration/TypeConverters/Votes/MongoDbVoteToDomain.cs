namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;

    public class MongoDbVoteToDomain : ITypeConverter<MongoDb.Entities.Vote, Domain.Models.Vote>
    {
        public Domain.Models.Vote Convert(MongoDb.Entities.Vote source, Domain.Models.Vote destination, ResolutionContext context)
        {
            destination = new Domain.Models.Vote
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