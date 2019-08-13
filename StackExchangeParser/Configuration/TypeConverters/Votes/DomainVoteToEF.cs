namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;
    using EF.Entities;

    public class DomainVoteToEF : ITypeConverter<Domain.Models.Vote, EF.Entities.Vote>
    {
        public EF.Entities.Vote Convert(Domain.Models.Vote source, Vote destination, ResolutionContext context)
        {
            destination = new EF.Entities.Vote
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