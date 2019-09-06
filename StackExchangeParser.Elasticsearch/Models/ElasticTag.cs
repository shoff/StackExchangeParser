namespace StackExchangeParser.Elasticsearch.Models
{
    using Domain.Models;
    using Nest;

    public class ElasticTag : ITag, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        public string TagName { get; set; }
        public int? Count { get; set; }
        public long? ExcerptPostId { get; set; }
        public int? WikiPostId { get; set; }
        public string IndexName => "{0}_tags";
    }
}