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

    public class BadgeParser : IBadgeParser
    {
        private readonly ILogger<BadgeParser> logger;
        private readonly string path;

        public BadgeParser(
            ILogger<BadgeParser> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public async Task<ICollection<IBadge>> ParseAsync(CancellationToken cancellationToken = default)
        {
            var badgeXml = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Badges.xml";
            this.logger.LogInformation($"Setting Badges.xml path to {badgeXml}");
            if (!File.Exists(badgeXml))
            {
                throw new FileNotFoundException($"The Badges.xml file does not exist at {badgeXml}");
            }
            var xelement = await File.ReadAllTextAsync(badgeXml, cancellationToken);
            var badgesXElements = XElement.Parse(xelement);
            var badges = new BlockingCollection<Badge>();

            Parallel.ForEach(badgesXElements.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException
                try
                {
                    var badge = new Badge();
                    badge.Name = e.Attribute("Name")?.Value;
                    badge.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    badge.Date = e.Attribute("Date") != null ? DateTime.Parse(e.Attribute("Date").Value) : DateTime.UtcNow;
                    badge.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    badge.Class = e.Attribute("Class") != null ? int.Parse(e.Attribute("Class")?.Value) : 0;
                    badge.TagBased = e.Attribute("TagBased")?.Value ?? "no_tag_based";

                    // ReSharper restore PossibleNullReferenceException
                    badges.Add(badge);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"BadgeParser Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {badges.Count} badges.");
            return badges.ToArray();
        }

        public ICollection<IBadge> Parse()
        {
            var badgeXml = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Badges.xml";
            this.logger.LogInformation($"Setting Badges.xml path to {badgeXml}");
            if (!File.Exists(badgeXml))
            {
                throw new FileNotFoundException($"The Badges.xml file does not exist at {badgeXml}");
            }

            var badgesXElements = XElement.Parse(File.ReadAllText(badgeXml));
            var badges = new BlockingCollection<Badge>();

            Parallel.ForEach(badgesXElements.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException
                try
                {
                    var badge = new Badge();
                    badge.Name = e.Attribute("Name")?.Value;
                    badge.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    badge.Date = e.Attribute("Date") != null ? DateTime.Parse(e.Attribute("Date").Value) : DateTime.UtcNow;
                    badge.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    badge.Class = e.Attribute("Class") != null ? int.Parse(e.Attribute("Class")?.Value) : 0;
                    badge.TagBased = e.Attribute("TagBased")?.Value ?? "no_tag_based";

                    // ReSharper restore PossibleNullReferenceException
                    badges.Add(badge);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"BadgeParser Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {badges.Count} badges.");
            return badges.ToArray();
        }
    }
}