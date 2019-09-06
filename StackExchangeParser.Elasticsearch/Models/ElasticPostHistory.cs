namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    public class ElasticPostHistory : IPostHistory, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        public int PostHistoryTypeId { get; set; }
        public long? PostId { get; set; }
        public ElasticPost Post { get; set; }
        public string RevisionGUID { get; set; }
        public DateTime CreationDate { get; set; }
        public long? UserId { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string IndexName => "{0}_post_histories";
    }
}