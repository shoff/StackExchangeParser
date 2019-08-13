namespace StackExchangeParser.Configuration.TypeConverters.PostHistories
{
    using AutoMapper;

    public class DomainPostHistoryToMongoDb : ITypeConverter<Domain.Models.PostHistory, MongoDb.Entities.PostHistory>
    {
        public MongoDb.Entities.PostHistory Convert(Domain.Models.PostHistory source, MongoDb.Entities.PostHistory destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.PostHistory
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