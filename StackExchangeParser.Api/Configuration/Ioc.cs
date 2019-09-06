namespace StackExchangeParser.Api.Configuration
{
    using ChaosMonkey.Guards;
    using Elasticsearch;
    using Elasticsearch.Configuration;
    using Elasticsearch.Infrastructure;
    using global::Elasticsearch.Net;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Nest;
    using ConnectionSettings = Elasticsearch.Infrastructure.ConnectionSettings;

    public static class Ioc
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISearchService, SearchService>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IClientManager, ClientManager>();
            services.AddSingleton<IConnectionPool, ConnectionPool>();
            services.AddSingleton<IConnection, Connection>();
            services.AddSingleton<IConnectionSettings, ConnectionSettings>();
            services.AddSingleton<ISearchClient, SearchClient>();
            services.AddSingleton<IElasticClient, HighLevelClient>();
            services.AddSingleton<IElasticLowLevelClient, LowLevelClient>();
            return services;
        }


        public static void VerifyOptions(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var options = sp.GetRequiredService<IOptions<ElasticSearch>>();
            // TODO why is the options not loading the section correctly?????
            Guard.IsNotNullOrWhitespace(options.Value.Server, nameof(options.Value.Server));
        }

    }
}