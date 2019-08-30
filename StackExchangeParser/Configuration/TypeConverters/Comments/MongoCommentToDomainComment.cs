namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;

    public class MongoCommentToDomainComment : ITypeConverter<MongoDb.Entities.Comment, Domain.Models.IComment>
    {
        public Domain.Models.IComment Convert(MongoDb.Entities.Comment source,  Domain.Models.IComment destination, ResolutionContext context)
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