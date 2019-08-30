namespace StackExchangeParser.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IXLinqRepository
    {
        Task<ICollection<IPost>> PostsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<IUser>> UsersAsync(CancellationToken cancellationToken = default);
        Task<ICollection<IComment>> CommentsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<ITag>> TagsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<IBadge>> BadgesAsync(CancellationToken cancellationToken = default);
        Task<ICollection<IPostHistory>> PostHistoriesAsync(CancellationToken cancellationToken = default);
        Task<ICollection<IVote>> VotesAsync(CancellationToken cancellationToken = default);
    }
}