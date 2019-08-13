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

        }

        public void Process()
        { 
            this.logger.LogInformation("Fetching and parsing xml posts.");
            var posts = this.linqRepository.Posts();

            this.logger.LogInformation("Fetching and parsing xml comments.");
            var comments = this.linqRepository.Comments();

            this.logger.LogInformation("Fetching and parsing xml tags.");
            var tags = this.linqRepository.Tags();

            this.logger.LogInformation("Fetching and parsing xml votes.");
            var votes = this.linqRepository.Votes();

            this.logger.LogInformation("Fetching and parsing xml badges.");
            var badges = this.linqRepository.Badges();

        }
    }
}