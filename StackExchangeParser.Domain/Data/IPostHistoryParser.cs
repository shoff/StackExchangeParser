namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IPostHistoryParser
    {
        ICollection<PostHistory> Parse();
        Task<ICollection<PostHistory>> ParseAsync(CancellationToken cancellationToken = default);
    }
}