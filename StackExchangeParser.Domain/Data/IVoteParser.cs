namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IVoteParser
    {
        ICollection<IVote> Parse();
        Task<ICollection<IVote>> ParseAsync(CancellationToken cancellationToken = default);

    }
}