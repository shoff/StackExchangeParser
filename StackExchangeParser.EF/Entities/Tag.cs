namespace StackExchangeParser.EF.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tags")]
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string TagName { get; set; }
        public int? Count { get; set; }
        [ForeignKey("ExcerptPost")]
        public long? ExcerptPostId { get; set; }
        public virtual Post ExcerptPost { get; set; }
        public int? WikiPostId { get; set; }
    }
}