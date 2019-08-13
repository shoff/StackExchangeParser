namespace StackExchangeParser.Configuration.TypeConverters.Tag
{
    using AutoMapper;
    using EF.Entities;

    public class DomainTagToEF : ITypeConverter<Domain.Models.Tag, EF.Entities.Tag>
    {
        public EF.Entities.Tag Convert(Domain.Models.Tag source, Tag destination, ResolutionContext context)
        {
            destination = new EF.Entities.Tag
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