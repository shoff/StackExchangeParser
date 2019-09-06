namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "elastic_comment")]
    public class ElasticComment : IComment, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "post_id")]
        public long? PostId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "score")]
        public int Score { get; set; }

        [Text(Name="text")]
        public string Text { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "user_id")]
        public long? UserId { get; set; }

        [Object]
        public User User { get; set; }

        [Ignore]
        public string IndexName => "{0}_comments";
    }
}