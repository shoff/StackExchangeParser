namespace StackExchangeParser.Configuration.TypeConverters.Tag
{
    using AutoMapper;
    using Elasticsearch.Models;

    // ReSharper disable once InconsistentNaming
    public class ITagToElasticTag : ITypeConverter<Domain.Models.ITag, ElasticTag>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticTag Convert(Domain.Models.ITag source, ElasticTag destination, ResolutionContext context)
        {
            destination = new ElasticTag
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