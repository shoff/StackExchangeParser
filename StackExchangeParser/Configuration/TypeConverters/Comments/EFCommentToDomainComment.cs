namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;

    public class EFCommentToDomainComment : ITypeConverter<EF.Entities.Comment, Domain.Models.Comment>
    {
        public Domain.Models.Comment Convert(EF.Entities.Comment source, Domain.Models.Comment destination, ResolutionContext context)
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