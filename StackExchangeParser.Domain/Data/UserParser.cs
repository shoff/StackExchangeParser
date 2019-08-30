namespace StackExchangeParser.Domain.Data
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;

    public class UserParser : IUserParser
    {
        private readonly ILogger<UserParser> logger;
        private readonly string path;

        public UserParser(
            ILogger<UserParser>logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public async Task<ICollection<IUser>> ParseAsync(CancellationToken cancellationToken = default)
        {
            var users = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Users.xml";
            this.logger.LogInformation($"Setting Users.xml path to {users}");
            if (!File.Exists(users))
            {
                throw new FileNotFoundException($"The Users.xml file does not exist at {users}");
            }

            var xelement = await File.ReadAllTextAsync(users, cancellationToken);
            var userXElement = XElement.Parse(xelement);
            var userItems = new BlockingCollection<User>();
            Parallel.ForEach(userXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var user = new User();
                    user.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    user.AccountId = e.Attribute("AccountId") != null ? long.Parse(e.Attribute("AccountId")?.Value) : 0;
                    user.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    user.Reputation = e.Attribute("Reputation") != null ? int.Parse(e.Attribute("Reputation")?.Value) : 0;
                    user.Views = e.Attribute("Views") != null ? int.Parse(e.Attribute("Views")?.Value) : 0;
                    user.UpVotes = e.Attribute("UpVotes") != null ? int.Parse(e.Attribute("UpVotes")?.Value) : 0;
                    user.DownVotes = e.Attribute("DownVotes") != null ? int.Parse(e.Attribute("DownVotes")?.Value) : 0;
                    user.WebsiteUrl = e.Attribute("WebsiteUrl")?.Value;
                    user.ProfileImageUrl = e.Attribute("ProfileImageUrl")?.Value;
                    user.Location = e.Attribute("Location")?.Value;
                    user.AboutMe = e.Attribute("AboutMe")?.Value;
                    user.DisplayName = e.Attribute("DisplayName")?.Value;
                    user.LastAccessDate = e.Attribute("LastAccessDate") != null ? DateTime.Parse(e.Attribute("LastAccessDate").Value) : DateTime.UtcNow;
                    // ReSharper restore PossibleNullReferenceException
                    userItems.Add(user);
                    // Console.WriteLine($"Added user: {user.DisplayName}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"User Parser: {ex.Message}");

                }
            });
            this.logger.LogInformation($"Parsed {userItems.Count} users.");
            return userItems.ToArray();
        }

        public ICollection<IUser> Parse()
        {
            var users = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Users.xml";
            this.logger.LogInformation($"Setting Users.xml path to {users}");
            if (!File.Exists(users))
            {
                throw new FileNotFoundException($"The Users.xml file does not exist at {users}");
            }

            var userXElement = XElement.Parse(File.ReadAllText(users));

            var userItems = new BlockingCollection<User>();
            Parallel.ForEach (userXElement.Elements("row"), e=>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var user = new User();
                    user.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    user.AccountId = e.Attribute("AccountId") != null ? long.Parse(e.Attribute("AccountId")?.Value) : 0;
                    user.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    user.Reputation = e.Attribute("Reputation") != null ? int.Parse(e.Attribute("Reputation")?.Value) : 0;
                    user.Views = e.Attribute("Views") != null ? int.Parse(e.Attribute("Views")?.Value) : 0;
                    user.UpVotes = e.Attribute("UpVotes") != null ? int.Parse(e.Attribute("UpVotes")?.Value) : 0;
                    user.DownVotes = e.Attribute("DownVotes") != null ? int.Parse(e.Attribute("DownVotes")?.Value) : 0;
                    user.WebsiteUrl = e.Attribute("WebsiteUrl")?.Value;
                    user.ProfileImageUrl = e.Attribute("ProfileImageUrl")?.Value;
                    user.Location = e.Attribute("Location")?.Value;
                    user.AboutMe = e.Attribute("AboutMe")?.Value;
                    user.DisplayName = e.Attribute("DisplayName")?.Value;
                    user.LastAccessDate = e.Attribute("LastAccessDate") != null ? DateTime.Parse(e.Attribute("LastAccessDate").Value) : DateTime.UtcNow;
                    // ReSharper restore PossibleNullReferenceException
                    userItems.Add(user);
                    // Console.WriteLine($"Added user: {user.DisplayName}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex,$"User Parser: {ex.Message}");

                }
            });
            this.logger.LogInformation($"Parsed {userItems.Count} users.");

            return userItems.ToArray();
        }
    }
}