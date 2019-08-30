namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using System.Collections.Generic;
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