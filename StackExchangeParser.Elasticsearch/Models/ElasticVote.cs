namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    public class ElasticVote : IVote, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        public long? PostId { get; set; }
        public int VoteTypeId { get; set; }
        public long? UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string IndexName => "{0}_votes";
    }
}