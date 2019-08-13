namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Badges;

    public class StackExchangeBadgeProfile : Profile
    {
        public StackExchangeBadgeProfile()
        {
            this.CreateMap<Domain.Models.Badge, EF.Entities.Badge>().ConvertUsing<DomainBadgeToEF>();
            this.CreateMap<Domain.Models.Badge, MongoDb.Entities.Badge>().ConvertUsing<DomainBadgeToMongoDb>();
            this.CreateMap<EF.Entities.Badge, Domain.Models.Badge>().ConvertUsing<EFBadgeToDomain>();
            this.CreateMap<MongoDb.Entities.Badge, Domain.Models.Badge>().ConvertUsing<MongoDbBadgeToDomain>();
        }
    }
}