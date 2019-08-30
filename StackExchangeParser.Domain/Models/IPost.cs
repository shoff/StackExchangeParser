namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IPost
    {
        long Id { get; set; }
        int PostTypeId { get; set; }
        DateTime CreationDate { get; set; }
        int Score { get; set; }
        int ViewCount { get; set; }
        string Body { get; set; }
        long? OwnerUserId { get; set; }
        string OwnerDisplayName { get; set; }
        string Type { get; set; }
        string LastEditorDisplayName { get; set; }
        DateTime? LastEditDate { get; set; }
        DateTime LastActivityDate { get; set; }
        string Title { get; set; }
        string Tags { get; set; }
        int CommentCount { get; set; }
        int FavoriteCount { get; set; }
        DateTime? ClosedDate { get; set; }
        long? LastEditorUserId { get; set; }
        int AnswerCount { get; set; }
    }
}