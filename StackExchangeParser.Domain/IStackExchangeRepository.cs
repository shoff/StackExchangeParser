namespace StackExchangeParser.Domain
{
    using System.Collections.Generic;
    using Models;

    public interface IStackExchangeRepository
    {
        ICollection<Post> Posts();
        ICollection<User> Users();
        ICollection<Comment> Comments();
        ICollection<Tag> Tags();
        ICollection<Badge> Badges();
        ICollection<PostHistory> PostHistories();
        ICollection<Vote> Votes();
    }
}