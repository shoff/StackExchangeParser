namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;
    using Elasticsearch.Models;

    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    public class ICommentToElasticComment : ITypeConverter<Domain.Models.IComment, ElasticComment>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticComment Convert(Domain.Models.IComment source, ElasticComment destination, ResolutionContext context)
        {
            destination = new ElasticComment
            {
                CreationDate = source.CreationDate,
                Id = source.Id,
                PostId = source.PostId,
                Score = source.Score,
                Text = source.Text,
                UserId = source.UserId
            };
            return destination;
        }
    }
}