namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "post_history")]
    public class ElasticPostHistory : IPostHistory, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "post_history_type_id")]
        public int PostHistoryTypeId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "post_id")]
        public long? PostId { get; set; }

        [Object]
        public ElasticPost Post { get; set; }

        [Text(Name = "revision_guid")]
        public string RevisionGUID { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long? UserId { get; set; }

        [Text(Name = "text")]
        public string Text { get; set; }

        [Text(Name = "comment")]
        public string Comment { get; set; }
        
        [Ignore]
        public string IndexName => "{0}_post_histories";
    }
}