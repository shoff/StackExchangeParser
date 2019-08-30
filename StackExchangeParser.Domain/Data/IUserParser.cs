namespace StackExchangeParser.Domain.Data
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    public interface IUserParser
    {
        Task<ICollection<IUser>> ParseAsync(CancellationToken cancellationToken = default);
        ICollection<IUser> Parse();
    }
}