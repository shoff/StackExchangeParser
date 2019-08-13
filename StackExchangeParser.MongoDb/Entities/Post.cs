namespace StackExchangeParser.MongoDb.Entities
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        public virtual long Id { get; set; }
        public virtual int PostTypeId { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual int Score { get; set; }
        public virtual int ViewCount { get; set; }
        public virtual string Body { get; set; }
        public virtual long? OwnerUserId { get; set; }
        public virtual string OwnerDisplayName { get; set; }
        public virtual string Type { get; set; }
        public virtual string LastEditorDisplayName { get; set; }
        public virtual DateTime? LastEditDate { get; set; }
        public virtual DateTime LastActivityDate { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tags { get; set; }
        public virtual int CommentCount { get; set; }
        public virtual int FavoriteCount { get; set; }
        public virtual DateTime? ClosedDate { get; set; }
        public virtual long? LastEditorUserId { get; set; }
        public virtual int AnswerCount { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}