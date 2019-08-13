namespace StackExchangeParser.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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