namespace StackExchangeParser.Elasticsearch.Extensions
{
    using Nest;

    // put here to stop the bleeding from all of the stupid fucking breaking changes 
    // the dumb fuck elastic team keep making between updates. Dumb asses.
    public static class ElasticClientExtensions
    {
        public static CreateIndexResponse CreateIndex<T>(this IElasticClient elasticClient, string name)
            where T : class
        {
            return elasticClient.Indices.Create(name, c => c.Map<T>(m => m.AutoMap()));
        }

    }
}