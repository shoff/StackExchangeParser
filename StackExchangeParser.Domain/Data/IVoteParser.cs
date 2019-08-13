namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IVoteParser
    {
        ICollection<Vote> Parse();
        Task<ICollection<Vote>> ParseAsync(CancellationToken cancellationToken = default);

    }
}