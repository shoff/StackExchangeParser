namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;
    using Users;

    public class StackExchangeUserProfile : Profile
    {
        public StackExchangeUserProfile()
        {
            this.CreateMap<MongoDb.Entities.User, IUser>().ConvertUsing<MongoUserToDomainUser>();
            this.CreateMap<User, MongoDb.Entities.User>().ConvertUsing<DomainUserToMongoUser>();
            this.CreateMap<IUser, ElasticUser>().ConvertUsing<IUserToElasticsearchUser>();
        }
    }
}