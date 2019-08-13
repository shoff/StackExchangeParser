namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;

    public class DomainCommentToMongoComment : ITypeConverter<Domain.Models.Comment, MongoDb.Entities.Comment>
    {
        public MongoDb.Entities.Comment Convert(Domain.Models.Comment source, MongoDb.Entities.Comment destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.Comment
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