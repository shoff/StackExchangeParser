namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;
    using Nest;

    public class ElasticPost : IPost, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        public int PostTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int ViewCount { get; set; }
        public string Body { get; set; }
        public long? OwnerUserId { get; set; }
        public string OwnerDisplayName { get; set; }
        public string Type { get; set; }
        public string LastEditorDisplayName { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int CommentCount { get; set; }
        public int FavoriteCount { get; set; }
        public DateTime? ClosedDate { get; set; }
        public long? LastEditorUserId { get; set; }
        public int AnswerCount { get; set; }
        [Object]
        public ICollection<ElasticComment> Comments { get; set; } = new HashSet<ElasticComment>();
        public string IndexName => "{0}_posts";
    }
}