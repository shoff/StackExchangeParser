namespace StackExchangeParser.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Feature
    {
        [Key]
        public long FeatureId { get; set; }

        public virtual ICollection<FeatureValue> Values { get; set; } = new HashSet<FeatureValue>();
        public virtual ICollection<FeatureToken> Tokens { get; set; } = new HashSet<FeatureToken>();
    }
}