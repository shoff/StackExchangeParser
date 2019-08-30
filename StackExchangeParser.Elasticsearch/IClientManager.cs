namespace StackExchangeParser.Elasticsearch
{
    using System;
    using System.Threading.Tasks;
    using global::Elasticsearch.Net;
    using Nest;

    public interface IClientManager
    {
        Task EnsureNewIndexIsCreatedAsync(string name, Func<CreateIndexDescriptor, ICreateIndexRequest> selector);
        ElasticClient HighLevelClient { get; }
        ElasticLowLevelClient LowLevelClient { get; }
    }
}