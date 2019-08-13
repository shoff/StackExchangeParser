namespace StackExchangeParser.Configuration.TypeConverters.Users
{
    using AutoMapper;
    using EF.Entities;

    public class DomainUserToEFUser : ITypeConverter<Domain.Models.User, EF.Entities.User>
    {
        public EF.Entities.User Convert(Domain.Models.User source, User destination, ResolutionContext context)
        {
            destination = new EF.Entities.User
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