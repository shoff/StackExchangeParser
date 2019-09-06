namespace StackExchangeParser.Api
{
    using System;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using Serilog.Debugging;
    using Serilog.Events;

    public class Program
    {
        private static string HostingEnvironment =>
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
        public static void Main(string[] args)
        {
            var serilogConfiguration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{HostingEnvironment}.json", true, true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .WriteTo.ColoredConsole()
                .ReadFrom.Configuration(serilogConfiguration)
                .CreateLogger();

            Log.Logger.Debug($"Currently operating in the {HostingEnvironment} hosting environment.");

            var host = CreateWebHostBuilder(args);
            host.Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, true);
                })
                //.UseSetting("https_port", "44388")
                .UseSerilog()
                .UseKestrel()
                //options => {
                //    options.Listen(IPAddress.Loopback, 5000); //HTTP port
                //    options.Listen(IPAddress.Loopback, 5001); //HTTPS port
                //})
                .UseStartup<Startup>()
                .Build();
        }

        internal static ILogger BuildLogger()
        {
            var serilogConfiguration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
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
    }
}