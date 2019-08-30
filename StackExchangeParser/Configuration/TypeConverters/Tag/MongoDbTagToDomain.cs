namespace StackExchangeParser.Configuration.TypeConverters.Tag
{
    using AutoMapper;

    public class MongoDbTagToDomain : ITypeConverter<MongoDb.Entities.Tag, Domain.Models.ITag> {
        public Domain.Models.ITag Convert(MongoDb.Entities.Tag source, Domain.Models.ITag destination, ResolutionContext context)
        {
            destination = new Domain.Models.Tag
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