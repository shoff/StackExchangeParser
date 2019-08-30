namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IBadgeParser
    {
        ICollection<IBadge> Parse();
        Task<ICollection<IBadge>> ParseAsync(CancellationToken cancellationToken = default);
    }
}