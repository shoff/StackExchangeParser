namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IUserParser
    {
        Task<ICollection<User>> ParseAsync(CancellationToken cancellationToken = default);
        ICollection<User> Parse();
    }
}