namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IPostHistory
    {
        long Id { get; set; }
        int PostHistoryTypeId { get; set; }
        long? PostId { get; set; }
        string RevisionGUID { get; set; }
        DateTime CreationDate { get; set; }
        long? UserId { get; set; }
        string Text { get; set; }
        string Comment { get; set; }
    }
}