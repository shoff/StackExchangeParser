namespace StackExchangeParser.Configuration.TypeConverters.PostHistories
{
    using AutoMapper;

    public class EFPostHistoryToDomain : ITypeConverter<EF.Entities.PostHistory, Domain.Models.PostHistory>
    {
        public Domain.Models.PostHistory Convert(EF.Entities.PostHistory source, Domain.Models.PostHistory destination, ResolutionContext context)
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