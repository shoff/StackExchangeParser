namespace StackExchangeParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public int PostTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int ViewCount { get; set; }
        public string Body { get; set; }

        [ForeignKey("Owner")]
        public long? OwnerUserId { get; set; }
        public virtual User Owner { get; set; }
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
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
}