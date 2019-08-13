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

    public class TagParser : ITagParser
    {
        private readonly ILogger<TagParser> logger;
        private readonly string path;

        public TagParser(
            ILogger<TagParser> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public ICollection<Tag> Parse()
        {
            var tagXml = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Tags.xml";
            this.logger.LogInformation($"Setting Tags.xml path to {tagXml}");
            if (!File.Exists(tagXml))
            {
                throw new FileNotFoundException($"The Tags.xml file does not exist at {tagXml}");
            }
            var tagsXElement = XElement.Parse(File.ReadAllText(tagXml));

            var tags = new BlockingCollection<Tag>();

            Parallel.ForEach (tagsXElement.Elements("row"), e=>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var tag = new Tag();
                    tag.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    tag.ExcerptPostId = e.Attribute("ExcerptPostId") != null ? long.Parse(e.Attribute("ExcerptPostId")?.Value) : 1;
                    tag.WikiPostId = e.Attribute("WikiPostId") != null ? int.Parse(e.Attribute("WikiPostId")?.Value) : 1;
                    tag.Count = e.Attribute("Count") != null ? int.Parse(e.Attribute("Count")?.Value) : 0;
                    tag.TagName = e.Attribute("TagName")?.Value;

                    // ReSharper restore PossibleNullReferenceException
                    tags.Add(tag);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {

                    this.logger.LogError(ex, $"PostHistory Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {tags.Count} tags.");
            return tags.ToArray();
        }
    }
}