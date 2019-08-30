namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IVote
    {
        long Id { get; set; }
        long? PostId { get; set; }
        int VoteTypeId { get; set; }
        long? UserId { get; set; }
        DateTime CreationDate { get; set; }
    }
}