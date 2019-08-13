namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using PostHistories;

    public class StackExchangePostHistoryProfile : Profile
    {
        public StackExchangePostHistoryProfile()
        {
            this.CreateMap<Domain.Models.PostHistory, EF.Entities.PostHistory>().ConvertUsing<DomainPostHistoryToEF>();
            this.CreateMap<Domain.Models.PostHistory, MongoDb.Entities.PostHistory>().ConvertUsing<DomainPostHistoryToMongoDb>();
            this.CreateMap<EF.Entities.PostHistory, Domain.Models.PostHistory>().ConvertUsing<EFPostHistoryToDomain>();
            this.CreateMap<MongoDb.Entities.PostHistory, Domain.Models.PostHistory>().ConvertUsing<MongoDbPostHistoryToDomain>();
        }
    }
}