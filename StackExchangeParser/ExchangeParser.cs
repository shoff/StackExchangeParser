namespace StackExchangeParser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.Extensions.Logging;
    using MongoDb;

    public class ExchangeParser : IExchangeParser
    {
        private readonly ILogger<ExchangeParser> logger;
        private readonly IMongoDbRepository mongoDbRepository;
        private readonly IXLinqRepository linqRepository;

        public ExchangeParser(
            ILogger<ExchangeParser> logger,
            IMongoDbRepository mongoDbRepository,
            IXLinqRepository linqRepository)
        {
            this.logger = logger;
            this.mongoDbRepository = mongoDbRepository;
            this.linqRepository = linqRepository;
        }

        public async Task ProcessDataAsync(CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation("Fetching and parsing xml users.");
            var users = await this.linqRepository.UsersAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending users to mongo");
            await this.mongoDbRepository.AddUsersAsync(users, cancellationToken).ConfigureAwait(false);
            
            this.logger.LogInformation("Fetching and parsing xml posts.");
            var posts = await this.linqRepository.PostsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending posts to mongo");
            await this.mongoDbRepository.AddPostsAsync(posts, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml comments.");
            var comments = await this.linqRepository.CommentsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending comments to mongo");
            await this.mongoDbRepository.AddCommentsAsync(comments, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml tags.");
            var tags = await this.linqRepository.TagsAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending tags to mongo");
            await this.mongoDbRepository.AddTagsAsync(tags, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml votes.");
            var votes = await this.linqRepository.VotesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending votes to mongo");
            await this.mongoDbRepository.AddVotesAsync(votes, cancellationToken).ConfigureAwait(false);

            this.logger.LogInformation("Fetching and parsing xml badges.");
            var badges = await this.linqRepository.BadgesAsync(cancellationToken).ConfigureAwait(false);
            this.logger.LogInformation("sending badges to mongo");
            await this.mongoDbRepository.AddBadgesAsync(badges, cancellationToken).ConfigureAwait(false);

        }

        public void Process()
        {


        }
    }
}