namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IPostHistoryParser
    {
        ICollection<IPostHistory> Parse();
        Task<ICollection<IPostHistory>> ParseAsync(CancellationToken cancellationToken = default);
    }
}