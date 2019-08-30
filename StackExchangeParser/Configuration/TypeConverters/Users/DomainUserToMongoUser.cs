namespace StackExchangeParser.Configuration.TypeConverters.Users
{
    using AutoMapper;
    using Domain.Models;

    public class DomainUserToMongoUser : ITypeConverter<IUser, MongoDb.Entities.User> {
        public MongoDb.Entities.User Convert(IUser source, MongoDb.Entities.User destination, ResolutionContext context)
        {
            destination = new MongoDb.Entities.User
            {
                AboutMe = source.AboutMe,
                AccountId = source.AccountId,
                CreationDate = source.CreationDate,
                DisplayName = source.DisplayName,
                DownVotes = source.DownVotes,
                Id = source.Id,
                LastAccessDate = source.LastAccessDate,
                Location = source.Location,
                ProfileImageUrl = source.ProfileImageUrl,
                Reputation = source.Reputation,
                Views = source.Views,
                WebsiteUrl = source.WebsiteUrl,
                UpVotes = source.UpVotes
            };
            return destination;
        }
    }
}