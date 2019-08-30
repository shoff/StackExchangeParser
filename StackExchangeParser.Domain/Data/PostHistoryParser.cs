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

    public class PostHistoryParser : IPostHistoryParser
    {
        private readonly ILogger<PostHistory> logger;
        private readonly string path;

        public PostHistoryParser(
            ILogger<PostHistory> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public async Task<ICollection<IPostHistory>> ParseAsync(CancellationToken cancellationToken = default)
        {
            var posts = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/PostHistory.xml";

            this.logger.LogInformation($"Setting PostHistory.xml path to {posts}");
            if (!File.Exists(posts))
            {
                throw new FileNotFoundException($"The PostHistory.xml file does not exist at {posts}");
            }
            var xelement = await File.ReadAllTextAsync(posts, cancellationToken);
            var postXElement = XElement.Parse(xelement);
            var postItems = new BlockingCollection<PostHistory>();

            Parallel.ForEach(postXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var post = new PostHistory();
                    post.RevisionGUID = e.Attribute("RevisionGUID")?.Value;
                    post.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    post.PostId = e.Attribute("PostId") != null ? long.Parse(e.Attribute("PostId")?.Value) : (long?)null;
                    post.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    post.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    post.PostHistoryTypeId = e.Attribute("PostHistoryTypeId") != null ? int.Parse(e.Attribute("PostHistoryTypeId")?.Value) : 0;
                    post.Comment = e.Attribute("Comment")?.Value ?? "no_comment";
                    post.Text = e.Attribute("Text")?.Value ?? "no_text";

                    // ReSharper restore PossibleNullReferenceException
                    postItems.Add(post);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"PostHistory Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {postItems.Count} post histories.");
            return postItems.ToArray();
        }


        public ICollection<IPostHistory> Parse()
        {
            var posts = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/PostHistory.xml";

            this.logger.LogInformation($"Setting PostHistory.xml path to {posts}");
            if (!File.Exists(posts))
            {
                throw new FileNotFoundException($"The PostHistory.xml file does not exist at {posts}");
            }
            var postXElement = XElement.Parse(File.ReadAllText(posts));

            var postItems = new BlockingCollection<PostHistory>();

            Parallel.ForEach(postXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var post = new PostHistory();
                    post.RevisionGUID = e.Attribute("RevisionGUID")?.Value;
                    post.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    post.PostId = e.Attribute("PostId") != null ? long.Parse(e.Attribute("PostId")?.Value) : (long?)null;
                    post.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    post.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    post.PostHistoryTypeId = e.Attribute("PostHistoryTypeId") != null ? int.Parse(e.Attribute("PostHistoryTypeId")?.Value) : 0;
                    post.Comment = e.Attribute("Comment")?.Value ?? "no_comment";
                    post.Text = e.Attribute("Text")?.Value ?? "no_text";

                    // ReSharper restore PossibleNullReferenceException
                    postItems.Add(post);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"PostHistory Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {postItems.Count} post histories.");
            return postItems.ToArray();
        }
    }
}