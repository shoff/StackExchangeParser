namespace StackExchangeParser.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FeatureToken
    {
        [Key]
        public long FeatureTokenId { get; set; }

        public string Token { get; set; }
    }
}