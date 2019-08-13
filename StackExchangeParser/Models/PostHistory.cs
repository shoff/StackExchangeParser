namespace StackExchangeParser.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public int PostHistoryTypeId { get; set; }
        [ForeignKey("Post")]
        public long? PostId { get; set; }
        public virtual Post Post { get; set; }
        public string RevisionGUID { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }

        public virtual User User { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
    }
}