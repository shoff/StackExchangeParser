namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using global::Elasticsearch.Net;

    public class LowLevelClient : ElasticLowLevelClient
    {
        private readonly IConnectionSettings connectionSettings;

        public LowLevelClient(IConnectionSettings connectionSettings)
            : base(connectionSettings as ConnectionSettings)
        {
            this.connectionSettings = connectionSettings;
        }

    }

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