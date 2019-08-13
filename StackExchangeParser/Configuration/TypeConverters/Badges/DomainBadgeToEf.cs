namespace StackExchangeParser.Configuration.TypeConverters.Badges
{
    using AutoMapper;
    using EF.Entities;

    public class DomainBadgeToEF : ITypeConverter<Domain.Models.Badge, EF.Entities.Badge>
    {
        public EF.Entities.Badge Convert(Domain.Models.Badge source, Badge destination, ResolutionContext context)
        {
            destination = new EF.Entities.Badge
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