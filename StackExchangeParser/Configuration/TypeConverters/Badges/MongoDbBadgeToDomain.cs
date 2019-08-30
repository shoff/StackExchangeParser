namespace StackExchangeParser.Configuration.TypeConverters.Badges
{
    using AutoMapper;

    public class MongoDbBadgeToDomain : ITypeConverter<MongoDb.Entities.Badge, Domain.Models.IBadge>
    {
        // ReSharper disable once RedundantAssignment
        public Domain.Models.IBadge Convert(MongoDb.Entities.Badge source, Domain.Models.IBadge destination, ResolutionContext context)
        {
            destination = new Domain.Models.Badge
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