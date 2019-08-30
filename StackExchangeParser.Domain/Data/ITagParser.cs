namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface ITagParser
    {
        ICollection<ITag> Parse();
        Task<ICollection<ITag>> ParseAsync(CancellationToken cancellationToken = default);
    }
}