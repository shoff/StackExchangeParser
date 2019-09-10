namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;
    using Tag;

    public class StackExchangeTagProfile : Profile
    {
        public StackExchangeTagProfile()
        {
            this.CreateMap<Domain.Models.Tag, MongoDb.Entities.Tag>().ConvertUsing<DomainTagToMongoDb>();
            this.CreateMap<MongoDb.Entities.Tag, Domain.Models.ITag>().ConvertUsing<MongoDbTagToDomain>();
            this.CreateMap<ITag, ElasticTag>().ConvertUsing<ITagToElasticTag>();
        }
    }
}