namespace StackExchangeParser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Infrastructure;
    using Microsoft.Extensions.Logging;

    public class ExchangeParser : IExchangeParser
    {
        private readonly ILogger<ExchangeParser> logger;
        private readonly IStackExchangeRepository stackExchangeRepository;
        private readonly IXLinqRepository linqRepository;

        public ExchangeParser(
            ILogger<ExchangeParser> logger,
            IStackExchangeRepository stackExchangeRepository,
            IXLinqRepository linqRepository)
        {
            this.logger = logger;
            this.stackExchangeRepository = stackExchangeRepository;
            this.linqRepository = linqRepository;
        }

        public async Task ProcessDataAsync(CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation("Fetching and parsing xml users.");
            var users = await this.linqRepository.UsersAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending users to mongo");
            await this.stackExchangeRepository.AddUsersAsync(users, cancellationToken).ConfigureAwait(false);
            
            this.logger.LogInformation("Fetching and parsing xml posts.");
            var posts = await this.linqRepository.PostsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending posts to mongo");
            await this.stackExchangeRepository.AddPostsAsync(posts, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml comments.");
            var comments = await this.linqRepository.CommentsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending comments to mongo");
            await this.stackExchangeRepository.AddCommentsAsync(comments, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml tags.");
            var tags = await this.linqRepository.TagsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending tags to mongo");
            await this.stackExchangeRepository.AddTagsAsync(tags, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml votes.");
            var votes = await this.linqRepository.VotesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending votes to mongo");
            await this.stackExchangeRepository.AddVotesAsync(votes, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml badges.");
            var badges = await this.linqRepository.BadgesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending badges to mongo");
            await this.stackExchangeRepository.AddBadgesAsync(badges, cancellationToken).ConfigureAwait(false);

        }
    }
}