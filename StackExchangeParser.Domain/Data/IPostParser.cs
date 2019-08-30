namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IPostParser
    {
        ICollection<IPost> Parse();
        Task<ICollection<IPost>> ParseAsync(CancellationToken cancellationToken = default);
    }
}