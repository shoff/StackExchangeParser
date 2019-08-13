namespace StackExchangeParser.EF.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comments")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        [ForeignKey("Post")]
        public long? PostId { get; set; }

        public virtual Post Post { get; set; }

        public int Score { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }

        public virtual User User { get; set; }
    }
}