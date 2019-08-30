namespace StackExchangeParser.Configuration.TypeConverters.Tag
{
    using AutoMapper;

    public class DomainTagToMongoDb : ITypeConverter<Domain.Models.ITag, MongoDb.Entities.Tag>
    {
        public MongoDb.Entities.Tag Convert(Domain.Models.ITag source, MongoDb.Entities.Tag destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.Tag
            {
                Count = source.Count,
                ExcerptPostId = source.ExcerptPostId,
                Id = source.Id,
                TagName = source.TagName,
                WikiPostId = source.WikiPostId
            };
            return destination;
        }
    }
}