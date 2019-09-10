namespace StackExchangeParser
{
    using System;
    using System.Threading.Tasks;
    using Configuration;
    using Domain;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Serilog.AspNetCore;
    using Serilog.Debugging;
    using Serilog.Events;

    class Program
    {
        private static readonly IServiceCollection services = new ServiceCollection();
        private static string HostingEnvironment =>
            Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process) ??
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);


        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddEnvironmentVariables()
                .AddInMemoryCollection()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{HostingEnvironment}.json", true, true)
                .AddJsonFile($"secrets.{HostingEnvironment}.json", true);

            Configuration = configuration.Build();
            Log.Logger = BuildLogger();

#pragma warning disable 618
            var serviceProvider = new Startup(Configuration, 
                new SerilogLoggerFactory(Log.Logger)).ConfigureServices(services);
#pragma warning restore 618

            Log.Information("Starting parsing");
            var parser = serviceProvider.GetRequiredService<IExchangeParser>();

            await parser.ProcessDataAsync()
                .ConfigureAwait(true);
            
            Log.Information("Completed parsing resources.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

        }
        internal static ILogger BuildLogger()
        {
            var serilogConfiguration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{HostingEnvironment}.json", true, true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                .ReadFrom.Configuration(serilogConfiguration)
                .CreateLogger();

            SelfLog.Enable(Console.WriteLine);

            return Log.Logger;
        }

        public static IConfiguration Configuration { get; private set; }

        //MLData data = new MLData();
        //data.MakeData();

        //var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

        //var indexes = new[] { "posts", "comments", "users" };

        //var connectionSettings = new ConnectionSettings(pool)
        //    //.DefaultIndex("posts")
        //    .PrettyJson()
        //    .DisableDirectStreaming()
        //    .OnRequestCompleted(response =>
        //    {
        //        // log out the request
        //        if (response.RequestBodyInBytes != null)
        //        {
        //            Console.WriteLine(
        //                $"{response.HttpMethod} {response.Uri} \n" +
        //                $"{Encoding.UTF8.GetString(response.RequestBodyInBytes)}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"{response.HttpMethod} {response.Uri}");
        //        }

        //        Console.WriteLine();

        //        // log out the response
        //        if (response.ResponseBodyInBytes != null)
        //        {
        //            Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
        //                $"{Encoding.UTF8.GetString(response.ResponseBodyInBytes)}\n" +
        //                $"{new string('-', 30)}\n");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
        //                $"{new string('-', 30)}\n");
        //        }
        //    });

        //var client = new ElasticClient(connectionSettings);

        //foreach (var index in indexes)
        //{
        //    if (client.IndexExists(index).Exists)
        //    {
        //        client.DeleteIndex(index);
        //    }
        //}

        //using (var context = new StackExchangeDbContext())
        //{
        //    users = context.Users.ToList();
        //    comments = context.Comments.ToList();
        //    posts = context.Posts.ToList();
        //}

        //client.CreateIndex("posts", m => m.Map<Post>(p => p.AutoMap()));
        //client.CreateIndex("comments", m => m.Map<Comment>(c => c.AutoMap()));
        //client.CreateIndex("users", m => m.Map<User>(c => c.AutoMap()));

        //client.IndexMany<User>(users, "users");
        //client.IndexMany<Comment>(comments, "comments");
        //client.IndexMany<Post>(posts, "posts");
    }
}
