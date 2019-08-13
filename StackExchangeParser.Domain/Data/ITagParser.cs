namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface ITagParser
    {
        ICollection<Tag> Parse();
    }
}