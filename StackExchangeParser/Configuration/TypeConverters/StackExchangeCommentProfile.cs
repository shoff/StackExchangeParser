namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Comments;

    public class StackExchangeCommentProfile : Profile
    {
        public StackExchangeCommentProfile()
        {
            // this.CreateMap<source,destination>
            this.CreateMap<Domain.Models.Comment, EF.Entities.Comment>().ConvertUsing<DomainCommentToEFComment>();
            this.CreateMap<Domain.Models.Comment, MongoDb.Entities.Comment>().ConvertUsing<DomainCommentToMongoComment>();
            this.CreateMap<EF.Entities.Comment, Domain.Models.Comment>().ConvertUsing<EFCommentToDomainComment>();
            this.CreateMap<MongoDb.Entities.Comment, Domain.Models.Comment>().ConvertUsing<MongoCommentToDomainComment>();
        }
    }
}