namespace StackExchangeParser.Elasticsearch.Infrastructure
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Elasticsearch.Net;
    using Nest;
    using Nest.Specification.CatApi;
    using Nest.Specification.ClusterApi;
    using Nest.Specification.CrossClusterReplicationApi;
    using Nest.Specification.GraphApi;
    using Nest.Specification.IndexLifecycleManagementApi;
    using Nest.Specification.IndicesApi;
    using Nest.Specification.IngestApi;
    using Nest.Specification.LicenseApi;
    using Nest.Specification.MachineLearningApi;
    using Nest.Specification.MigrationApi;
    using Nest.Specification.NodesApi;
    using Nest.Specification.RollupApi;
    using Nest.Specification.SecurityApi;
    using Nest.Specification.SnapshotApi;
    using Nest.Specification.SqlApi;
    using Nest.Specification.TasksApi;
    using Nest.Specification.WatcherApi;
    using Nest.Specification.XPackApi;

    public interface ISearchClient
    {
        BulkResponse Bulk(Func<BulkDescriptor, IBulkRequest> selector);
        Task<BulkResponse> BulkAsync(Func<BulkDescriptor, IBulkRequest> selector, CancellationToken ct);
        BulkResponse Bulk(IBulkRequest request);
        Task<BulkResponse> BulkAsync(IBulkRequest request, CancellationToken ct);
        ClearScrollResponse ClearScroll(Func<ClearScrollDescriptor, IClearScrollRequest> selector);
        Task<ClearScrollResponse> ClearScrollAsync(Func<ClearScrollDescriptor, IClearScrollRequest> selector, CancellationToken ct);
        ClearScrollResponse ClearScroll(IClearScrollRequest request);
        Task<ClearScrollResponse> ClearScrollAsync(IClearScrollRequest request, CancellationToken ct);
        CountResponse Count(ICountRequest request);
        Task<CountResponse> CountAsync(ICountRequest request, CancellationToken ct);
        DeleteResponse Delete(IDeleteRequest request);
        Task<DeleteResponse> DeleteAsync(IDeleteRequest request, CancellationToken ct);
        DeleteByQueryResponse DeleteByQuery(IDeleteByQueryRequest request);
        Task<DeleteByQueryResponse> DeleteByQueryAsync(IDeleteByQueryRequest request, CancellationToken ct);
        ListTasksResponse DeleteByQueryRethrottle(TaskId taskId, Func<DeleteByQueryRethrottleDescriptor, IDeleteByQueryRethrottleRequest> selector);
        Task<ListTasksResponse> DeleteByQueryRethrottleAsync(TaskId taskId, Func<DeleteByQueryRethrottleDescriptor, IDeleteByQueryRethrottleRequest> selector, CancellationToken ct);
        ListTasksResponse DeleteByQueryRethrottle(IDeleteByQueryRethrottleRequest request);
        Task<ListTasksResponse> DeleteByQueryRethrottleAsync(IDeleteByQueryRethrottleRequest request, CancellationToken ct);
        DeleteScriptResponse DeleteScript(Id id, Func<DeleteScriptDescriptor, IDeleteScriptRequest> selector);
        Task<DeleteScriptResponse> DeleteScriptAsync(Id id, Func<DeleteScriptDescriptor, IDeleteScriptRequest> selector, CancellationToken ct);
        DeleteScriptResponse DeleteScript(IDeleteScriptRequest request);
        Task<DeleteScriptResponse> DeleteScriptAsync(IDeleteScriptRequest request, CancellationToken ct);
        ExistsResponse DocumentExists(IDocumentExistsRequest request);
        Task<ExistsResponse> DocumentExistsAsync(IDocumentExistsRequest request, CancellationToken ct);
        ExistsResponse SourceExists(ISourceExistsRequest request);
        Task<ExistsResponse> SourceExistsAsync(ISourceExistsRequest request, CancellationToken ct);
        FieldCapabilitiesResponse FieldCapabilities(Indices index, Func<FieldCapabilitiesDescriptor, IFieldCapabilitiesRequest> selector);
        Task<FieldCapabilitiesResponse> FieldCapabilitiesAsync(Indices index, Func<FieldCapabilitiesDescriptor, IFieldCapabilitiesRequest> selector, CancellationToken ct);
        FieldCapabilitiesResponse FieldCapabilities(IFieldCapabilitiesRequest request);
        Task<FieldCapabilitiesResponse> FieldCapabilitiesAsync(IFieldCapabilitiesRequest request, CancellationToken ct);
        GetScriptResponse GetScript(Id id, Func<GetScriptDescriptor, IGetScriptRequest> selector);
        Task<GetScriptResponse> GetScriptAsync(Id id, Func<GetScriptDescriptor, IGetScriptRequest> selector, CancellationToken ct);
        GetScriptResponse GetScript(IGetScriptRequest request);
        Task<GetScriptResponse> GetScriptAsync(IGetScriptRequest request, CancellationToken ct);
        RootNodeInfoResponse RootNodeInfo(Func<RootNodeInfoDescriptor, IRootNodeInfoRequest> selector);
        Task<RootNodeInfoResponse> RootNodeInfoAsync(Func<RootNodeInfoDescriptor, IRootNodeInfoRequest> selector, CancellationToken ct);
        RootNodeInfoResponse RootNodeInfo(IRootNodeInfoRequest request);
        Task<RootNodeInfoResponse> RootNodeInfoAsync(IRootNodeInfoRequest request, CancellationToken ct);
        MultiGetResponse MultiGet(Func<MultiGetDescriptor, IMultiGetRequest> selector);
        Task<MultiGetResponse> MultiGetAsync(Func<MultiGetDescriptor, IMultiGetRequest> selector, CancellationToken ct);
        MultiGetResponse MultiGet(IMultiGetRequest request);
        Task<MultiGetResponse> MultiGetAsync(IMultiGetRequest request, CancellationToken ct);
        MultiSearchResponse MultiSearch(Indices index, Func<MultiSearchDescriptor, IMultiSearchRequest> selector);
        Task<MultiSearchResponse> MultiSearchAsync(Indices index, Func<MultiSearchDescriptor, IMultiSearchRequest> selector, CancellationToken ct);
        MultiSearchResponse MultiSearch(IMultiSearchRequest request);
        Task<MultiSearchResponse> MultiSearchAsync(IMultiSearchRequest request, CancellationToken ct);
        MultiSearchResponse MultiSearchTemplate(Indices index, Func<MultiSearchTemplateDescriptor, IMultiSearchTemplateRequest> selector);
        Task<MultiSearchResponse> MultiSearchTemplateAsync(Indices index, Func<MultiSearchTemplateDescriptor, IMultiSearchTemplateRequest> selector, CancellationToken ct);
        MultiSearchResponse MultiSearchTemplate(IMultiSearchTemplateRequest request);
        Task<MultiSearchResponse> MultiSearchTemplateAsync(IMultiSearchTemplateRequest request, CancellationToken ct);
        MultiTermVectorsResponse MultiTermVectors(Func<MultiTermVectorsDescriptor, IMultiTermVectorsRequest> selector);
        Task<MultiTermVectorsResponse> MultiTermVectorsAsync(Func<MultiTermVectorsDescriptor, IMultiTermVectorsRequest> selector, CancellationToken ct);
        MultiTermVectorsResponse MultiTermVectors(IMultiTermVectorsRequest request);
        Task<MultiTermVectorsResponse> MultiTermVectorsAsync(IMultiTermVectorsRequest request, CancellationToken ct);
        PingResponse Ping(Func<PingDescriptor, IPingRequest> selector);
        Task<PingResponse> PingAsync(Func<PingDescriptor, IPingRequest> selector, CancellationToken ct);
        PingResponse Ping(IPingRequest request);
        Task<PingResponse> PingAsync(IPingRequest request, CancellationToken ct);
        PutScriptResponse PutScript(Id id, Func<PutScriptDescriptor, IPutScriptRequest> selector);
        Task<PutScriptResponse> PutScriptAsync(Id id, Func<PutScriptDescriptor, IPutScriptRequest> selector, CancellationToken ct);
        PutScriptResponse PutScript(IPutScriptRequest request);
        Task<PutScriptResponse> PutScriptAsync(IPutScriptRequest request, CancellationToken ct);
        ReindexOnServerResponse ReindexOnServer(Func<ReindexOnServerDescriptor, IReindexOnServerRequest> selector);
        Task<ReindexOnServerResponse> ReindexOnServerAsync(Func<ReindexOnServerDescriptor, IReindexOnServerRequest> selector, CancellationToken ct);
        ReindexOnServerResponse ReindexOnServer(IReindexOnServerRequest request);
        Task<ReindexOnServerResponse> ReindexOnServerAsync(IReindexOnServerRequest request, CancellationToken ct);
        ReindexRethrottleResponse ReindexRethrottle(TaskId taskId, Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector);
        Task<ReindexRethrottleResponse> ReindexRethrottleAsync(TaskId taskId, Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector, CancellationToken ct);
        ReindexRethrottleResponse ReindexRethrottle(IReindexRethrottleRequest request);
        Task<ReindexRethrottleResponse> ReindexRethrottleAsync(IReindexRethrottleRequest request, CancellationToken ct);
        RenderSearchTemplateResponse RenderSearchTemplate(Func<RenderSearchTemplateDescriptor, IRenderSearchTemplateRequest> selector);
        Task<RenderSearchTemplateResponse> RenderSearchTemplateAsync(Func<RenderSearchTemplateDescriptor, IRenderSearchTemplateRequest> selector, CancellationToken ct);
        RenderSearchTemplateResponse RenderSearchTemplate(IRenderSearchTemplateRequest request);
        Task<RenderSearchTemplateResponse> RenderSearchTemplateAsync(IRenderSearchTemplateRequest request, CancellationToken ct);
       UpdateByQueryResponse UpdateByQuery(IUpdateByQueryRequest request);
        Task<UpdateByQueryResponse> UpdateByQueryAsync(IUpdateByQueryRequest request, CancellationToken ct);
        ListTasksResponse UpdateByQueryRethrottle(TaskId taskId, Func<UpdateByQueryRethrottleDescriptor, IUpdateByQueryRethrottleRequest> selector);
        Task<ListTasksResponse> UpdateByQueryRethrottleAsync(TaskId taskId, Func<UpdateByQueryRethrottleDescriptor, IUpdateByQueryRethrottleRequest> selector, CancellationToken ct);
        ListTasksResponse UpdateByQueryRethrottle(IUpdateByQueryRethrottleRequest request);
        Task<ListTasksResponse> UpdateByQueryRethrottleAsync(IUpdateByQueryRethrottleRequest request, CancellationToken ct);
        PutMappingResponse Map(IPutMappingRequest request);
        Task<PutMappingResponse> MapAsync(IPutMappingRequest request, CancellationToken ct);
        IConnectionSettingsValues ConnectionSettings { get; }
        Inferrer Infer { get; }
        IElasticLowLevelClient LowLevel { get; }
        IElasticsearchSerializer RequestResponseSerializer { get; }
        IElasticsearchSerializer SourceSerializer { get; }
        CatNamespace Cat { get;  }
        ClusterNamespace Cluster { get; }
        CrossClusterReplicationNamespace CrossClusterReplication { get; }
        GraphNamespace Graph { get; }
        IndexLifecycleManagementNamespace IndexLifecycleManagement { get; }
        IndicesNamespace Indices { get; }
        IngestNamespace Ingest { get; }
        LicenseNamespace License { get; }
        MachineLearningNamespace MachineLearning { get; }
        MigrationNamespace Migration { get; }
        NodesNamespace Nodes { get; }
        RollupNamespace Rollup { get; }
        SecurityNamespace Security { get; }
        SnapshotNamespace Snapshot { get;  }
        SqlNamespace Sql { get;  }
        TasksNamespace Tasks { get; }
        WatcherNamespace Watcher { get; }
        XPackNamespace XPack { get;  }
    }
}