namespace StackExchangeParser.Configuration.TypeConverters.Posts
{
    using AutoMapper;
    using Domain.Models;

    public class MongoPostToDomainPost : ITypeConverter<MongoDb.Entities.Post, IPost>
    {
        public IPost Convert(MongoDb.Entities.Post source, IPost destination, ResolutionContext context)
        {
            destination = new Post
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