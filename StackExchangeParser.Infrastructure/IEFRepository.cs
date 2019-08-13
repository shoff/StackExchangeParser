namespace StackExchangeParser.Infrastructure
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IEFRepository
    {
        ICollection<Post> Posts();
        ICollection<User> Users();
        ICollection<Comment> Comments();
        ICollection<Tag> Tags();
        ICollection<Badge> Badges();
        ICollection<PostHistory> PostHistories();
    }
}