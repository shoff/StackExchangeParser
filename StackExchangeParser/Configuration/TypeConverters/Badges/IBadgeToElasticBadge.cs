namespace StackExchangeParser.Configuration.TypeConverters.Badges
{
    using AutoMapper;
    using Elasticsearch.Models;

    // ReSharper disable once InconsistentNaming
    public class IBadgeToElasticBadge: ITypeConverter<Domain.Models.IBadge, ElasticBadge>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticBadge Convert(Domain.Models.IBadge source, ElasticBadge destination, ResolutionContext context)
        {
            destination = new ElasticBadge
            {
                Class = source.Class,
                Date = source.Date,
                Id = source.Id,
                Name = source.Name,
                TagBased = source.TagBased,
                UserId = source.UserId
            };
            return destination;
        }
    }
}