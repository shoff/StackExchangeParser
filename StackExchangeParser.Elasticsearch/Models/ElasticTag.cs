namespace StackExchangeParser.Elasticsearch.Models
{
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "tag")]
    public class ElasticTag : ITag, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }

        [Text(Name = "tag_name")]
        public string TagName { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "count")]
        public int? Count { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "excerpt_post_id")]
        public long? ExcerptPostId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "wiki_post_id")]
        public int? WikiPostId { get; set; }

        [Ignore]
        public string IndexName => "{0}_tags";
    }
}