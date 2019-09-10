namespace StackExchangeParser.Elasticsearch.Configuration
{
    public class ElasticSearch
    {
        public string Scheme { get; set; } = "http://";
        public string Port { get; set; } = "9200";
        public string Server { get; set; } = "localhost";
    }
}