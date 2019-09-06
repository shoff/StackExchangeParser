namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    public class ElasticBadge : IBadge, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        [Number(DocValues = false, IgnoreMalformed = true, Name = "user_id")]
        public long? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Class { get; set; }
        public string TagBased { get; set; }
        public string IndexName => "{0}_badges";
    }
}