namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;

    public class MongoDbVoteToDomain : ITypeConverter<MongoDb.Entities.Vote, Domain.Models.IVote>
    {
        public Domain.Models.IVote Convert(MongoDb.Entities.Vote source, Domain.Models.IVote destination, ResolutionContext context)
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