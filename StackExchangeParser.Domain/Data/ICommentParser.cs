namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface ICommentParser
    {
        ICollection<IComment> Parse();
        Task<ICollection<IComment>> ParseAsync(CancellationToken cancellationToken = default);
    }
}