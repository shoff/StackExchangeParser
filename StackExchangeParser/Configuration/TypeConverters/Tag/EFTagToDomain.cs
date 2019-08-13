namespace StackExchangeParser.Configuration.TypeConverters.Tag
{
    using AutoMapper;
    using EF.Entities;

    public class EFTagToDomain : ITypeConverter<EF.Entities.Tag, Domain.Models.Tag> {
        public Domain.Models.Tag Convert(Tag source, Domain.Models.Tag destination, ResolutionContext context)
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