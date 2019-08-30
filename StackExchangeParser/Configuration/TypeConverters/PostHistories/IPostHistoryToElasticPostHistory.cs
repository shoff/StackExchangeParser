namespace StackExchangeParser.Configuration.TypeConverters.PostHistories
{
    using AutoMapper;
    using Elasticsearch.Models;

    // ReSharper disable once InconsistentNaming
    public class IPostHistoryToElasticPostHistory : ITypeConverter<Domain.Models.IPostHistory, ElasticPostHistory>
    {
        // ReSharper disable once RedundantAssignment
        public ElasticPostHistory Convert(Domain.Models.IPostHistory source, ElasticPostHistory destination, ResolutionContext context)
        {
            destination = new ElasticPostHistory
            {
                CreationDate = source.CreationDate,
                Id = source.Id,
                PostHistoryTypeId = source.PostHistoryTypeId,
                PostId = source.PostId,
                RevisionGUID = source.RevisionGUID,
                Text = source.Text,
                Comment = source.Comment,
                UserId = source.UserId
            };
            return destination;
        }
    }
}