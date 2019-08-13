namespace StackExchangeParser.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FeatureValue
    {
        [Key]
        public long FeatureId { get; set; }

        public float Value { get; set; }
    }
}