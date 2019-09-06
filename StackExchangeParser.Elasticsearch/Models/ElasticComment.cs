namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    public class ElasticComment : IComment, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        public long? PostId { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }
        public string IndexName => "{0}_comments";
    }
}