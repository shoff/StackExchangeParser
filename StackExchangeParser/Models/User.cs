namespace StackExchangeParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public int Reputation { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string WebsiteUrl { get; set; }
        public string Location { get; set; }
        public string AboutMe { get; set; }
        public int Views { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public long AccountId { get; set; }
        public string ProfileImageUrl { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Badge> Badges { get; set; } = new HashSet<Badge>();
        public virtual ICollection<PostHistory> PostHistories { get; set; } = new HashSet<PostHistory>();
    }
}