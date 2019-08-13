namespace StackExchangeParser.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Models;

    public interface IXLinqRepository : IStackExchangeRepository
    {
        Task<ICollection<Post>> PostsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<User>> UsersAsync(CancellationToken cancellationToken = default);
        Task<ICollection<Comment>> CommentsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<Tag>> TagsAsync(CancellationToken cancellationToken = default);
        Task<ICollection<Badge>> BadgesAsync(CancellationToken cancellationToken = default);
        Task<ICollection<PostHistory>> PostHistoriesAsync(CancellationToken cancellationToken = default);
        Task<ICollection<Vote>> VotesAsync(CancellationToken cancellationToken = default);
    }
}