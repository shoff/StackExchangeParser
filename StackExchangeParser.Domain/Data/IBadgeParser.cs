namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IBadgeParser
    {
        ICollection<Badge> Parse();
        Task<ICollection<Badge>> ParseAsync(CancellationToken cancellationToken = default);
    }
}