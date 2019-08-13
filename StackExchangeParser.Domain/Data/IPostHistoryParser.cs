namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface IPostHistoryParser
    {
        ICollection<PostHistory> Parse();
    }
}