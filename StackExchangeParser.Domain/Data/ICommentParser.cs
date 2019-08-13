namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using Models;

    public interface ICommentParser
    {
        ICollection<Comment> Parse();
    }
}