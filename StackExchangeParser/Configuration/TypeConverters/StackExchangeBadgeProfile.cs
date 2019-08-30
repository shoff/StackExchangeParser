namespace StackExchangeParser.Configuration.TypeConverters
{
    using AutoMapper;
    using Badges;
    using Domain.Models;
    using Elasticsearch.Models;

    public class StackExchangeBadgeProfile : Profile
    {
        public StackExchangeBadgeProfile()
        {
            this.CreateMap<Domain.Models.Badge, EF.Entities.Badge>().ConvertUsing<DomainBadgeToEF>();
            this.CreateMap<Domain.Models.IBadge, MongoDb.Entities.Badge>().ConvertUsing<DomainBadgeToMongoDb>();
            this.CreateMap<EF.Entities.Badge, Domain.Models.Badge>().ConvertUsing<EFBadgeToDomain>();
            this.CreateMap<MongoDb.Entities.Badge, Domain.Models.IBadge>().ConvertUsing<MongoDbBadgeToDomain>();

            this.CreateMap<IBadge, ElasticBadge>().ConvertUsing<IBadgeToElasticBadge>();

        }
    }
}