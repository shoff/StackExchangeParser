namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;

    public class EFVoteToDomain : ITypeConverter<EF.Entities.Vote, Domain.Models.Vote>
    {
        public Domain.Models.Vote Convert(EF.Entities.Vote source, Domain.Models.Vote destination, ResolutionContext context)
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