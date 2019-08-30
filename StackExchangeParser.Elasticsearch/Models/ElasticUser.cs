namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using Domain.Models;
    using Nest;

    [ElasticsearchType(RelationName = "user")]
    public class ElasticUser : IUser, IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "id")]
        public long Id { get; set; }
        [Number(DocValues = false, IgnoreMalformed = false, Name = "reputation")]
        public int Reputation { get; set; }
        [Date(Format = "MM-dd-yyyy")]
        public DateTime CreationDate { get; set; }
        [Text(Name="display_name")]
        public string DisplayName { get; set; }
        [Date(Format = "MM-dd-yyyy")]
        public DateTime LastAccessDate { get; set; }
        [Text(Name="website_url")]
        public string WebsiteUrl { get; set; }
        [Text(Name="location")]
        public string Location { get; set; }
        [Text(Name="about_me")]
        public string AboutMe { get; set; }
        [Number(DocValues = false, IgnoreMalformed = false, Name = "views")]
        public int Views { get; set; }
        [Number(DocValues = false, IgnoreMalformed = false, Name = "up_votes")]
        public int UpVotes { get; set; }
        [Number(DocValues = false, IgnoreMalformed = false, Name = "down_votes")]
        public int DownVotes { get; set; }
        [Number(DocValues = false, IgnoreMalformed = false, Name = "account_id")]
        public long AccountId { get; set; }
        [Text(Name= "profile_image_url")]
        public string ProfileImageUrl { get; set; }
        public string IndexName => "{0}_users";
    }
}