namespace StackExchangeParser.MongoDb
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IMongoDbRepository
    {
        ICollection<User> Users();
        ICollection<Post> Posts();
        ICollection<Comment> Comments();
        ICollection<Tag> Tags();
        ICollection<Badge> Badges();
        ICollection<PostHistory> PostHistories();
        ICollection<Vote> Votes();
        Task AddUsersAsync(ICollection<User> users, CancellationToken cancellationToken = default);
        Task AddPostsAsync(ICollection<Post> posts, CancellationToken cancellationToken = default);
        Task AddCommentsAsync(ICollection<Comment> comments, CancellationToken cancellationToken = default);
        Task AddTagsAsync(ICollection<Tag> tags, CancellationToken cancellationToken = default);
        Task AddBadgesAsync(ICollection<Badge> badges, CancellationToken cancellationToken = default);
        Task AddPostHistoriesAsync(ICollection<PostHistory> postHistories, CancellationToken cancellationToken = default);
        Task AddVotesAsync(ICollection<Vote> votes, CancellationToken cancellationToken = default);
    }
}