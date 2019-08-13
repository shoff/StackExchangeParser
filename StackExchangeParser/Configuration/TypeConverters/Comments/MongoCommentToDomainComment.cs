namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;

    public class MongoCommentToDomainComment : ITypeConverter<MongoDb.Entities.Comment, Domain.Models.Comment>
    {
        public Domain.Models.Comment Convert(MongoDb.Entities.Comment source,  Domain.Models.Comment destination, ResolutionContext context)
        {
            destination = new Domain.Models.Comment
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