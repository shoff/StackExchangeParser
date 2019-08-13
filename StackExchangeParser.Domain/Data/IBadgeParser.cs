namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface IBadgeParser
    {
        ICollection<Badge> Parse();
    }
}