namespace StackExchangeParser.Configuration.TypeConverters.Users
{
    using AutoMapper;
    using Domain.Models;

    public class MongoUserToDomainUser : ITypeConverter<MongoDb.Entities.User, IUser>
    {
        public IUser Convert(MongoDb.Entities.User source, IUser destination, ResolutionContext context)
        {
            destination = new User
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