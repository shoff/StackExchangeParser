namespace StackExchangeParser.Domain.Models
{
    using System;

    public interface IUser
    {
        long Id { get; set; }
        int Reputation { get; set; }
        DateTime CreationDate { get; set; }
        string DisplayName { get; set; }
        DateTime LastAccessDate { get; set; }
        string WebsiteUrl { get; set; }
        string Location { get; set; }
        string AboutMe { get; set; }
        int Views { get; set; }
        int UpVotes { get; set; }
        int DownVotes { get; set; }
        long AccountId { get; set; }
        string ProfileImageUrl { get; set; }
    }
}