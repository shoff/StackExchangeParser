namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Tag;

    public class StackExchangeTagProfile : Profile
    {
        public StackExchangeTagProfile()
        {
            this.CreateMap<Domain.Models.Tag, EF.Entities.Tag>().ConvertUsing<DomainTagToEF>();
            this.CreateMap<Domain.Models.Tag, MongoDb.Entities.Tag>().ConvertUsing<DomainTagToMongoDb>();
            this.CreateMap<EF.Entities.Tag, Domain.Models.Tag>().ConvertUsing<EFTagToDomain>();
            this.CreateMap<MongoDb.Entities.Tag, Domain.Models.ITag>().ConvertUsing<MongoDbTagToDomain>();
        }
    }
}