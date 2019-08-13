namespace StackExchangeParser.Configuration.TypeConverters.Badges
{
    using AutoMapper;

    public class MongoDbBadgeToDomain : ITypeConverter<MongoDb.Entities.Badge, Domain.Models.Badge>
    {
        public Domain.Models.Badge Convert(MongoDb.Entities.Badge source, Domain.Models.Badge destination, ResolutionContext context)
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