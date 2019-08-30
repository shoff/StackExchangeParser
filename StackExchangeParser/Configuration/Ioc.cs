namespace StackExchangeParser.Configuration
{
    using Domain;
    using Domain.Data;
    using Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    using ML.Net;
    using MongoDb;

    public class Ioc
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBadgeParser, BadgeParser>();
            services.AddTransient<ICommentParser, CommentParser>();
            services.AddTransient<IPostHistoryParser, PostHistoryParser>();
            services.AddTransient<IPostParser, PostParser>();
            services.AddTransient<ITagParser, TagParser>();
            services.AddTransient<IUserParser, UserParser>();
            services.AddTransient<IVoteParser, VoteParser>();

            services.AddSingleton<IStackExchangeRepository, MongoDbRepository>();
            services.AddTransient<IXLinqRepository, XLinqRepository>();

            services.AddTransient<IMLData, MLData>();
            services.AddTransient<IExchangeParser, ExchangeParser>();
            return services;
        }
    }
}