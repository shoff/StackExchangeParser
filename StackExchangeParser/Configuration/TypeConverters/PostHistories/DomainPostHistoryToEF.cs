namespace StackExchangeParser.Configuration.TypeConverters.PostHistories
{
    using AutoMapper;
    using EF.Entities;

    public class DomainPostHistoryToEF : ITypeConverter<Domain.Models.PostHistory, EF.Entities.PostHistory>
    {
        public PostHistory Convert(Domain.Models.PostHistory source, PostHistory destination, ResolutionContext context)
        {
            destination = new PostHistory
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