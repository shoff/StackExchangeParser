namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "post")]
    public class ElasticPost : IPost, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "post_type_id")]
        public int PostTypeId { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "score")]
        public int Score { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "view_count")]
        public int ViewCount { get; set; }

        [Text(Name="body")]
        public string Body { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "owner_user_id")]
        public long? OwnerUserId { get; set; }

        [Text(Name="owner_display_name")]
        public string OwnerDisplayName { get; set; }

        [Text(Name="type")]
        public string Type { get; set; }

        [Text(Name="last_editor_display_name")]
        public string LastEditorDisplayName { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "last_edit_date")]
        public DateTime? LastEditDate { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "last_activity_date")]
        public DateTime LastActivityDate { get; set; }

        [Text(Name="title")]
        public string Title { get; set; }

        [Text(Name = "tags")]
        public string Tags { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "comment_count")]
        public int CommentCount { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "favorite_count")]
        public int FavoriteCount { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "closed_date")]
        public DateTime? ClosedDate { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "last_editor_user_id")]
        public long? LastEditorUserId { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "answer_count")]
        public int AnswerCount { get; set; }

        [Object]
        public ICollection<ElasticComment> Comments { get; set; } = new HashSet<ElasticComment>();

        [Ignore]
        public string IndexName => "{0}_posts";
    }
}