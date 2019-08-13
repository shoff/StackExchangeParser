namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IPostParser
    {
        ICollection<Post> Parse();
        Task<ICollection<Post>> ParseAsync(CancellationToken cancellationToken = default);
    }
}