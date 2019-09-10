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

    public class ClientManager : IClientManager
    {
        private readonly ILogger<ClientManager> logger;
        private readonly IConnectionSettings connectionSettings;
        private readonly Uri serverUri;

        public ClientManager(
            ILogger<ClientManager> logger,
            IOptions<ElasticSearch> options,
            IConnectionSettings connectionSettings)
        {
            this.logger = logger;
            this.connectionSettings = connectionSettings;
            this.serverUri = new Uri($"{options.Value.Scheme}{options.Value.Server}:{options.Value.Port}");
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