namespace StackExchangeParser.Domain.Data
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;

    public class VoteParser : IVoteParser
    {
        private readonly ILogger<VoteParser> logger;
        private readonly string path;

        public VoteParser(
            ILogger<VoteParser> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public ICollection<Vote> Parse()
        {
            var voteXml = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Votes.xml";
            this.logger.LogInformation($"Setting Votes.xml path to {voteXml}");
            if (!File.Exists(voteXml))
            {
                throw new FileNotFoundException($"The Votes.xml file does not exist at {voteXml}");
            }
            var voteXElement = XElement.Parse(File.ReadAllText(voteXml));
            var votes = new BlockingCollection<Vote>();
            Parallel.ForEach(voteXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException
                try
                {
                    var vote = new Vote();
                    vote.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    vote.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    vote.PostId = e.Attribute("PostId") != null ? long.Parse(e.Attribute("PostId")?.Value) : 1;
                    vote.CreationDate = e.Attribute("CreationDate") != null
                        ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    // ReSharper restore PossibleNullReferenceException
                    votes.Add(vote);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"VoteParser Parser {ex.Message}");
                }
            });
            this.logger.LogInformation($"Parsed {votes.Count} votes.");
            return votes.ToArray();
        }
    }
}