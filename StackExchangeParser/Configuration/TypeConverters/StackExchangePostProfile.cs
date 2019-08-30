namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Posts;

    public class StackExchangePostProfile : Profile
    {
        public StackExchangePostProfile()
        {
            this.CreateMap<Post, EF.Entities.Post>().ConvertUsing<DomainPostToEFPost>();
            this.CreateMap<Post, MongoDb.Entities.Post>().ConvertUsing<DomainPostToMongoPost>();
            this.CreateMap<EF.Entities.Post, Post>().ConvertUsing<EFPostToDomainPost>();
            this.CreateMap<MongoDb.Entities.Post, IPost>().ConvertUsing<MongoPostToDomainPost>();
        }
    }
}