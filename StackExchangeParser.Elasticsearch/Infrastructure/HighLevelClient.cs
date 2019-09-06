namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    public class HighLevelClient : Nest.ElasticClient
    {
        private readonly IConnectionSettings connectionSettings;

        public HighLevelClient(IConnectionSettings connectionSettings)
            : base(connectionSettings as ConnectionSettings)
        {
            this.connectionSettings = connectionSettings;
        }
    }
}