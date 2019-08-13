namespace StackExchangeParser.Configuration.TypeConverters.Comments
{
    using AutoMapper;
    using EF.Entities;

    public class DomainCommentToEFComment : ITypeConverter<Domain.Models.Comment, EF.Entities.Comment>
    {
        public Comment Convert(Domain.Models.Comment source, Comment destination, ResolutionContext context)
        {
            destination = new Comment
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