namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IBadge
    {
        long Id { get; set; }
        long? UserId { get; set; }
        User User { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        int Class { get; set; }
        string TagBased { get; set; }
    }
}