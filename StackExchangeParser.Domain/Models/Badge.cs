namespace StackExchangeParser.Domain.Models
{
    using System;

    public class Badge : IBadge
    {
        public virtual long Id { get; set; }
        public virtual long? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int Class { get; set; }
        public virtual string TagBased { get; set; }
    }
}