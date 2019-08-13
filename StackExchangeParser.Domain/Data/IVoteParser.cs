namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface IVoteParser
    {
        ICollection<Vote> Parse();
    }
}