namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Domain.Models;
    using Users;

    public class StackExchangeUserProfile : Profile
    {
        public StackExchangeUserProfile()
        {
            this.CreateMap<EF.Entities.User, User>().ConvertUsing<EFUserToDomainUser>();
            this.CreateMap<MongoDb.Entities.User, IUser>().ConvertUsing<MongoUserToDomainUser>();
            this.CreateMap<User, EF.Entities.User>().ConvertUsing<DomainUserToEFUser>();
            this.CreateMap<User, MongoDb.Entities.User>().ConvertUsing<DomainUserToMongoUser>();
        }
    }
}