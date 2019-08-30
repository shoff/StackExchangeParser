// ReSharper disable once UnusedMember.Global
namespace StackExchangeParser.Configuration.TypeConverters.Votes
{
    using AutoMapper;
    using Elasticsearch.Models;
    // ReSharper disable once UnusedMember.Global
    public class IVoteToElasticVote : ITypeConverter<Domain.Models.IVote, ElasticVote>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticVote Convert(Domain.Models.IVote source, ElasticVote destination, ResolutionContext context)
        {
            destination = new ElasticVote
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