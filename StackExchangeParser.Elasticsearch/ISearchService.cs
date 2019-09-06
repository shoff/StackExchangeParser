namespace StackExchangeParser.Elasticsearch
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface ISearchService
    {
        int FinalFailureCount { get; set; }
        int TotalFailures { get; }
        bool BulkIndex { get; set; }
        Queue<object> FailedChunks { get; }
        int ErrorCountBreakPoint { get; set; }
        int DocumentThresholdAdjustment { get; set; }
        bool RetryFailedChunks { get; set; }
        bool SaveFailedDocumentsToDisk { get; set; }
        string FailedDirectory { get; set; }
        int MaximumNumberOfDocumentsPerInsert { get; }
        Task AddUsersAsync(ICollection<IUser> users, CancellationToken cancellationToken);
        Task AddPostsAsync(ICollection<IPost> posts, CancellationToken cancellationToken);
        Task AddCommentsAsync(ICollection<IComment> comments, CancellationToken cancellationToken);
        Task AddTagsAsync(ICollection<ITag> tags, CancellationToken cancellationToken);
        Task AddVotesAsync(ICollection<IVote> votes, CancellationToken cancellationToken);
        Task AddBadgesAsync(ICollection<IBadge> badges, CancellationToken cancellationToken);
    }
}