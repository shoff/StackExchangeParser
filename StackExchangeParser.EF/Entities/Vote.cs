namespace StackExchangeParser.EF.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Votes")]
    public class Vote
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public long? PostId { get; set; }
        public int VoteTypeId { get; set; }
        public long? UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}