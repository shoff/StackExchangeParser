namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface IPostParser
    {
        ICollection<Post> Parse();
    }
}