namespace StackExchangeParser.Configuration
{
    using Domain;
    using Domain.Data;
    using Elasticsearch;
    using Elasticsearch.Infrastructure;
    using global::Elasticsearch.Net;
    using Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    using ML.Net;
    using Nest;
    using ConnectionSettings = Elasticsearch.Infrastructure.ConnectionSettings;

    public static class Ioc
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IBadgeParser, BadgeParser>();
            services.AddTransient<ICommentParser, CommentParser>();
            services.AddTransient<IPostHistoryParser, PostHistoryParser>();
            services.AddTransient<IPostParser, PostParser>();
            services.AddTransient<ITagParser, TagParser>();
            services.AddTransient<IUserParser, UserParser>();
            services.AddTransient<IVoteParser, VoteParser>();
            services.ConfigureSearch();
            services.AddSingleton<IClientManager, ClientManager>();
            services.AddSingleton<IStackExchangeRepository, SearchService>();
            services.AddTransient<IXLinqRepository, XLinqRepository>();

            services.AddTransient<IMLData, MLData>();
            services.AddTransient<IExchangeParser, ExchangeParser>();

            return services;
        }

        public static IServiceCollection ConfigureSearch(this IServiceCollection services)
        {

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IConnectionPool, ConnectionPool>();
            services.AddSingleton<IConnection, Connection>();
            services.AddSingleton<IConnectionSettings, ConnectionSettings>();
            services.AddSingleton<ISearchClient, SearchClient>();
            services.AddSingleton<IElasticClient, HighLevelClient>();
            services.AddSingleton<IElasticLowLevelClient, LowLevelClient>();
            return services;
        }
    }
}