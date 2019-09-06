namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "vote")]
    public class ElasticVote : IVote, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "post_id")]
        public long? PostId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "vote_type_id")]
        public int VoteTypeId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = true, Name = "user_id")]
        public long? UserId { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Ignore]
        public string IndexName => "{0}_votes";
    }
}