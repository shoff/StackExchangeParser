namespace StackExchangeParser.Domain.Data
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Xml.Linq;
    using Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;

    public class PostParser : IPostParser
    {
        private readonly ILogger<Post> logger;
        private readonly string path;

        public PostParser(
            ILogger<Post> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public async Task<ICollection<Post>> ParseAsync(CancellationToken cancellationToken = default)
        {
            var posts = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Posts.xml";
            this.logger.LogInformation($"Setting Posts.xml path to {posts}");
            if (!File.Exists(posts))
            {
                throw new FileNotFoundException($"The Posts.xml file does not exist at {posts}");
            }

            var xelement = await File.ReadAllTextAsync(posts, cancellationToken);

            var postXElement = XElement.Parse(xelement);
            var postItems = new BlockingCollection<Post>();
            var postsJson = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Posts.json";

            if (File.Exists(postsJson))
            {
                File.Delete(postsJson);
            }

            Parallel.ForEach(postXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var post = new Post();
                    post.OwnerDisplayName = e.Attribute("OwnerDisplayName")?.Value ?? "no_owner_display_name";
                    post.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    post.PostTypeId = e.Attribute("PostTypeId") != null ? int.Parse(e.Attribute("PostTypeId")?.Value) : 0;
                    post.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    post.Score = e.Attribute("Score") != null ? int.Parse(e.Attribute("Score")?.Value) : 0;
                    post.ViewCount = e.Attribute("ViewCount") != null ? int.Parse(e.Attribute("ViewCount")?.Value) : 0;
                    post.Body = e.Attribute("Body")?.Value;
                    post.OwnerUserId = e.Attribute("OwnerUserId") != null ? long.Parse(e.Attribute("OwnerUserId")?.Value) : 1;
                    post.LastEditorUserId = e.Attribute("LastEditorUserId") != null ? long.Parse(e.Attribute("LastEditorUserId")?.Value) : (long?)null;
                    post.AnswerCount = e.Attribute("AnswerCount") != null ? int.Parse(e.Attribute("AnswerCount")?.Value) : 0;
                    post.Type = e.Attribute("Type")?.Value;
                    post.LastEditorDisplayName = e.Attribute("LastEditorDisplayName")?.Value;
                    post.LastEditDate = e.Attribute("LastEditDate") != null ? DateTime.Parse(e.Attribute("LastEditDate").Value) : DateTime.UtcNow;
                    post.LastActivityDate = e.Attribute("LastActivityDate") != null ? DateTime.Parse(e.Attribute("LastActivityDate").Value) : DateTime.UtcNow;
                    post.Title = e.Attribute("Title")?.Value;
                    post.Tags = e.Attribute("Tags")?.Value;
                    post.CommentCount = e.Attribute("CommentCount") != null ? int.Parse(e.Attribute("CommentCount")?.Value) : 0;
                    post.FavoriteCount = e.Attribute("FavoriteCount") != null ? int.Parse(e.Attribute("FavoriteCount")?.Value) : 0;
                    post.ClosedDate = e.Attribute("ClosedDate") != null ? DateTime.Parse(e.Attribute("ClosedDate").Value) : DateTime.UtcNow;

                    // ReSharper restore PossibleNullReferenceException
                    postItems.Add(post);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Posts Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {postItems.Count} posts.");
            return postItems.ToArray();
        }

        public ICollection<Post> Parse()
        {
            var posts = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Posts.xml";
            this.logger.LogInformation($"Setting Posts.xml path to {posts}");
            if (!File.Exists(posts))
            {
                throw new FileNotFoundException($"The Posts.xml file does not exist at {posts}");
            }

            var postXElement = XElement.Parse(File.ReadAllText(posts));

            var postItems = new BlockingCollection<Post>();
            var postsJson = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Posts.json";

            if (File.Exists(postsJson))
            {
                File.Delete(postsJson);
            }

            Parallel.ForEach (postXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var post = new Post();
                    post.OwnerDisplayName = e.Attribute("OwnerDisplayName")?.Value ?? "no_owner_display_name";
                    post.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    post.PostTypeId = e.Attribute("PostTypeId") != null ? int.Parse(e.Attribute("PostTypeId")?.Value) : 0;
                    post.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    post.Score = e.Attribute("Score") != null ? int.Parse(e.Attribute("Score")?.Value) : 0;
                    post.ViewCount = e.Attribute("ViewCount") != null ? int.Parse(e.Attribute("ViewCount")?.Value) : 0;
                    post.Body = e.Attribute("Body")?.Value;
                    post.OwnerUserId = e.Attribute("OwnerUserId") != null ? long.Parse(e.Attribute("OwnerUserId")?.Value) : 1;
                    post.LastEditorUserId = e.Attribute("LastEditorUserId") != null ? long.Parse(e.Attribute("LastEditorUserId")?.Value) : (long?)null;
                    post.AnswerCount = e.Attribute("AnswerCount") != null ? int.Parse(e.Attribute("AnswerCount")?.Value) : 0;
                    post.Type = e.Attribute("Type")?.Value;
                    post.LastEditorDisplayName = e.Attribute("LastEditorDisplayName")?.Value;
                    post.LastEditDate = e.Attribute("LastEditDate") != null ? DateTime.Parse(e.Attribute("LastEditDate").Value) : DateTime.UtcNow;
                    post.LastActivityDate = e.Attribute("LastActivityDate") != null ? DateTime.Parse(e.Attribute("LastActivityDate").Value) : DateTime.UtcNow;
                    post.Title = e.Attribute("Title")?.Value;
                    post.Tags = e.Attribute("Tags")?.Value;
                    post.CommentCount = e.Attribute("CommentCount") != null ? int.Parse(e.Attribute("CommentCount")?.Value) : 0;
                    post.FavoriteCount = e.Attribute("FavoriteCount") != null ? int.Parse(e.Attribute("FavoriteCount")?.Value) : 0;
                    post.ClosedDate = e.Attribute("ClosedDate") != null ? DateTime.Parse(e.Attribute("ClosedDate").Value) : DateTime.UtcNow;

                    // ReSharper restore PossibleNullReferenceException
                    postItems.Add(post);
                    // Console.WriteLine($"Added post: {post.Title}");
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Posts Parser {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {postItems.Count} posts.");
            return postItems.ToArray();
        }

        private static string StripHtmlTags(string html)
        {
            if (String.IsNullOrEmpty(html))
            {
                return "";
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
        }
    }
}