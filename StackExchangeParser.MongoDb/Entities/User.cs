namespace StackExchangeParser.MongoDb.Entities
{
    using System;
    using Domain.Models;

    public class User : IUser
    {
        public virtual long Id { get; set; }
        public virtual int Reputation { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual DateTime LastAccessDate { get; set; }
        public virtual string WebsiteUrl { get; set; }
        public virtual string Location { get; set; }
        public virtual string AboutMe { get; set; }
        public virtual int Views { get; set; }
        public virtual int UpVotes { get; set; }
        public virtual int DownVotes { get; set; }
        public virtual long AccountId { get; set; }
        public virtual string ProfileImageUrl { get; set; }
    }
}