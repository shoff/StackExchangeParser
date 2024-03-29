﻿namespace StackExchangeParser.Configuration.TypeConverters.Badges
{
    using AutoMapper;

    public class DomainBadgeToMongoDb : ITypeConverter<Domain.Models.IBadge, MongoDb.Entities.Badge>
    {
        public MongoDb.Entities.Badge Convert(Domain.Models.IBadge source, MongoDb.Entities.Badge destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.Badge
            {
                Class = source.Class,
                Date = source.Date,
                Id = source.Id,
                Name = source.Name,
                TagBased = source.TagBased,
                UserId = source.UserId
            };
            return destination;
        }
    }
}