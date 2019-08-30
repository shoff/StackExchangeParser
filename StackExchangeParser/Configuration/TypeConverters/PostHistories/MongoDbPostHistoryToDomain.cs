namespace StackExchangeParser.Configuration.TypeConverters.PostHistories
{
    using AutoMapper;

    public class MongoDbPostHistoryToDomain : ITypeConverter<MongoDb.Entities.PostHistory, Domain.Models.IPostHistory>
    {
        public Domain.Models.IPostHistory Convert(MongoDb.Entities.PostHistory source, Domain.Models.IPostHistory destination, ResolutionContext context)
        {
            destination = new Domain.Models.PostHistory
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