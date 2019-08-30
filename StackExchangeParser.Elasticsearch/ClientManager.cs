namespace StackExchangeParser.Elasticsearch
{
    using System;
    using System.Threading.Tasks;
    using Configuration;
    using global::Elasticsearch.Net;
    using Infrastructure;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Nest;
    using ConnectionSettings = Nest.ConnectionSettings;

    public class ClientManager : IClientManager
    {
        private readonly IOptions<ElasticSearch> elasticOptions;
        private readonly IOptions<ElasticSearch> options;
        private readonly ILogger<ClientManager> logger;
        private readonly IConnectionSettings connectionSettings;
        private readonly Uri serverUri;

        public ClientManager(
            IOptions<ElasticSearch> options,
            ILogger<ClientManager> logger,
            IConnectionSettings connectionSettings)
        {
            this.options = options;
            this.logger = logger;
            this.connectionSettings = connectionSettings;
            this.serverUri = new Uri($"{this.options.Value.Scheme}{this.options.Value.Server}:{this.options.Value.Port}");
            this.CreateClients();
        }

        private void CreateClients()
        {
            var connectionConfiguration = new ConnectionConfiguration(this.serverUri)
                .DisableAutomaticProxyDetection()
                .EnableHttpCompression()
                .DisableDirectStreaming()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            this.LowLevelClient = new ElasticLowLevelClient(connectionConfiguration);
            this.HighLevelClient = new ElasticClient(this.serverUri);
        }
        

        public Task EnsureNewIndexIsCreatedAsync(string name, Func<CreateIndexDescriptor, ICreateIndexRequest> selector)
        {
            if (this.HighLevelClient.Indices.Exists(name).Exists)
            {
                this.logger.LogDebug($"Index {name} already exists.");
                this.HighLevelClient.Indices.Delete(name);
            }

            this.logger.LogInformation($"Create index {name}");
            return Task.FromResult(this.HighLevelClient.Indices.CreateAsync(name, selector));
        }

        public ElasticClient HighLevelClient { get; private set; }
        public ElasticLowLevelClient LowLevelClient { get; private set; }
    }
}