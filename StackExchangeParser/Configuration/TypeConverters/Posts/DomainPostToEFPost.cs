namespace StackExchangeParser.Configuration.TypeConverters.Posts
{
    using AutoMapper;
    using EF.Entities;

    public class DomainPostToEFPost : ITypeConverter<Domain.Models.Post, EF.Entities.Post>
    {
        public Post Convert(Domain.Models.Post source, Post destination, ResolutionContext context)
        {
            destination = new EF.Entities.Post
            {
                AnswerCount = source.AnswerCount,
                Body = source.Body,
                ClosedDate = source.ClosedDate,
                CommentCount = source.CommentCount,
                CreationDate = source.CreationDate,
                FavoriteCount = source.FavoriteCount,
                Id = source.Id,
                LastActivityDate = source.LastActivityDate,
                LastEditDate = source.LastEditDate,
                LastEditorDisplayName = source.LastEditorDisplayName,
                LastEditorUserId = source.LastEditorUserId,
                OwnerDisplayName = source.OwnerDisplayName,
                OwnerUserId = source.OwnerUserId,
                PostTypeId = source.PostTypeId,
                Score = source.Score,
                Title = source.Title,
                Type = source.Type,
                ViewCount = source.ViewCount
            };
            return destination;
        }
    }
}