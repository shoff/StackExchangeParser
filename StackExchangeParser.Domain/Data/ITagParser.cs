namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface ITagParser
    {
        ICollection<Tag> Parse();
        Task<ICollection<Tag>> ParseAsync(CancellationToken cancellationToken = default);
    }
}