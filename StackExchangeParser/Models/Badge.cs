namespace StackExchangeParser.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Badge
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long Id { get; set; }
        [ForeignKey("User")]
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Class { get; set; }
        public string TagBased { get; set; }
    }
}