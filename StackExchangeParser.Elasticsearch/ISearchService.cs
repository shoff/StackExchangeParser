namespace StackExchangeParser.Elasticsearch
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface ISearchService
    {
        bool BulkIndex { get; set; }
        ICollection<IPost> Posts();
        ICollection<IUser> Users();
        ICollection<IComment> Comments();
        ICollection<ITag> Tags();
        ICollection<IBadge> Badges();
        ICollection<IPostHistory> PostHistories();
        ICollection<IVote> Votes();
        Task AddUsersAsync(ICollection<IUser> users, CancellationToken cancellationToken);
        Task AddPostsAsync(ICollection<IPost> posts, CancellationToken cancellationToken);
        Task AddCommentsAsync(ICollection<IComment> comments, CancellationToken cancellationToken);
        Task AddTagsAsync(ICollection<ITag> tags, CancellationToken cancellationToken);
        Task AddVotesAsync(ICollection<IVote> votes, CancellationToken cancellationToken);
        Task AddBadgesAsync(ICollection<IBadge> badges, CancellationToken cancellationToken);
    }
}