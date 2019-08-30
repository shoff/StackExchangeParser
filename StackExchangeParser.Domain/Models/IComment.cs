namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IComment
    {
        long Id { get; set; }
        long? PostId { get; set; }
        int Score { get; set; }
        string Text { get; set; }
        DateTime CreationDate { get; set; }
        long? UserId { get; set; }
        User User { get; set; }
    }
}