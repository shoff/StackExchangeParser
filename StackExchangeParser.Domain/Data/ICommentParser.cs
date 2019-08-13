namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface ICommentParser
    {
        ICollection<Comment> Parse();
        Task<ICollection<Comment>> ParseAsync(CancellationToken cancellationToken = default);
    }
}