namespace StackExchangeParser.Configuration.TypeConverters.Users
{
    using AutoMapper;
    using EF.Entities;

    public class EFUserToDomainUser : ITypeConverter<EF.Entities.User, Domain.Models.User>
    {
        public Domain.Models.User Convert(User source, Domain.Models.User destination, ResolutionContext context)
        {
            destination = new Domain.Models.User
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