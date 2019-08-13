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

    public class CommentParser : ICommentParser
    {
        private readonly ILogger<CommentParser> logger;
        private readonly string path;

        public CommentParser(
            ILogger<CommentParser> logger,
            IOptions<StackExchangeData> options)
        {
            this.logger = logger;
            this.path = options.Value.Path;
        }

        public async Task<ICollection<Comment>> ParseAsync(CancellationToken cancellationToken = default)
        {
            var commentsXMl = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Comments.xml";
            this.logger.LogInformation($"Setting Comments.xml path to {commentsXMl}");
            if (!File.Exists(commentsXMl))
            {
                throw new FileNotFoundException($"The Comments.cml file does not exist at {commentsXMl}");
            }

            var xelement = await File.ReadAllTextAsync(commentsXMl, cancellationToken);
            var commentsXElement = XElement.Parse(xelement);
            var comments = new BlockingCollection<Comment>();

            Parallel.ForEach(commentsXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var comment = new Comment();
                    comment.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    comment.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    comment.PostId = e.Attribute("PostId") != null ? long.Parse(e.Attribute("PostId")?.Value) : 1; ;
                    comment.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    comment.Score = e.Attribute("Score") != null ? int.Parse(e.Attribute("Score")?.Value) : 0;
                    comment.Text = !string.IsNullOrWhiteSpace(e.Attribute("Text")?.Value) ? StripHtmlTags(e.Attribute("Text")?.Value) : "no_text";
                    // ReSharper restore PossibleNullReferenceException
                    comments.Add(comment);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Comments Parser: {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {comments.Count} comments.");
            return comments.ToArray();
        }

        public ICollection<Comment> Parse()
        {
            var commentsXMl = AppDomain.CurrentDomain.BaseDirectory + $"{this.path}/Comments.xml";
            this.logger.LogInformation($"Setting Comments.xml path to {commentsXMl}");
            if (!File.Exists(commentsXMl))
            {
                throw new FileNotFoundException($"The Comments.cml file does not exist at {commentsXMl}");
            }


            var commentsXElement = XElement.Parse(File.ReadAllText(commentsXMl));
            var comments = new BlockingCollection<Comment>();

            Parallel.ForEach(commentsXElement.Elements("row"), e =>
            {
                // ReSharper disable PossibleNullReferenceException

                try
                {
                    var comment = new Comment();
                    comment.Id = e.Attribute("Id") != null ? long.Parse(e.Attribute("Id")?.Value) : 0;
                    comment.UserId = e.Attribute("UserId") != null ? long.Parse(e.Attribute("UserId")?.Value) : 1;
                    comment.PostId = e.Attribute("PostId") != null ? long.Parse(e.Attribute("PostId")?.Value) : 1; ;
                    comment.CreationDate = e.Attribute("CreationDate") != null ? DateTime.Parse(e.Attribute("CreationDate").Value) : DateTime.UtcNow;
                    comment.Score = e.Attribute("Score") != null ? int.Parse(e.Attribute("Score")?.Value) : 0;
                    comment.Text = !string.IsNullOrWhiteSpace(e.Attribute("Text")?.Value) ? StripHtmlTags(e.Attribute("Text")?.Value) : "no_text";
                    // ReSharper restore PossibleNullReferenceException
                    comments.Add(comment);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Comments Parser: {ex.Message}");
                }
            });

            this.logger.LogInformation($"Parsed {comments.Count} comments.");
            return comments.ToArray();
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