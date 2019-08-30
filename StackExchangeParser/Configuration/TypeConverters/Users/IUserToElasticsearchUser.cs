// ReSharper disable InconsistentNaming
namespace StackExchangeParser.Configuration.TypeConverters.Users
{
    using AutoMapper;
    using Domain.Models;
    using Elasticsearch.Models;

    public class IUserToElasticsearchUser : ITypeConverter<IUser, ElasticUser>
    {
        public ElasticUser Convert(IUser source, ElasticUser destination, ResolutionContext context)
        {
            destination = new ElasticUser
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