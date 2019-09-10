namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;
    using Posts;

    public class StackExchangePostProfile : Profile
    {
        public StackExchangePostProfile()
        {
            this.CreateMap<Post, MongoDb.Entities.Post>().ConvertUsing<DomainPostToMongoPost>();
            this.CreateMap<MongoDb.Entities.Post, IPost>().ConvertUsing<MongoPostToDomainPost>();
            this.CreateMap<IPost, ElasticPost>().ConvertUsing<IPostToElasticPost>();
        }
    }
}