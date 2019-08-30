namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;
    using PostHistories;

    public class StackExchangePostHistoryProfile : Profile
    {
        public StackExchangePostHistoryProfile()
        {
            this.CreateMap<PostHistory, EF.Entities.PostHistory>().ConvertUsing<DomainPostHistoryToEF>();
            this.CreateMap<PostHistory, MongoDb.Entities.PostHistory>().ConvertUsing<DomainPostHistoryToMongoDb>();
            this.CreateMap<EF.Entities.PostHistory, PostHistory>().ConvertUsing<EFPostHistoryToDomain>();
            this.CreateMap<MongoDb.Entities.PostHistory, IPostHistory>().ConvertUsing<MongoDbPostHistoryToDomain>();
            this.CreateMap<IPostHistory, ElasticPostHistory>().ConvertUsing<IPostHistoryToElasticPostHistory>();
        }
    }
}