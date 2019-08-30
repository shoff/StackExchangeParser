// ReSharper disable UnusedMember.Global
namespace StackExchangeParser.Configuration.TypeConverters.Posts
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;

    // ReSharper disable once InconsistentNaming
    public class IPostToElasticPost : ITypeConverter<IPost, ElasticPost>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticPost Convert(IPost source, ElasticPost destination, ResolutionContext context)
        {
            destination = new ElasticPost
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