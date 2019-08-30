namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using Nest;

    public class SearchClient : ElasticClient, ISearchClient
    {
        private readonly IConnectionSettings connectionSettings;

        public SearchClient(IConnectionSettings connectionSettings)
            : base(connectionSettings as ConnectionSettings)
        {
            this.connectionSettings = connectionSettings;
        }
    }
}