namespace StackExchangeParser
{
    using System;
    using AutoMapper;
    using Configuration;
    using Configuration.TypeConverters;
    using Domain.Configuration;
    using EF;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using MongoDb;
    using Serilog;
    using Serilog.AspNetCore;

    public class Startup
    {

        public Startup(
            IConfiguration configuration, 
            SerilogLoggerFactory serilogLoggerFactory)
        {
            this.Configuration = configuration;
            this.SerilogLoggerFactory = serilogLoggerFactory;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSingleton(factory => this.SerilogLoggerFactory);
            services.AddLogging(configure => configure.AddSerilog());
            services.Configure<EFConnection>(Configuration.GetSection("EFConnection"));
            services.Configure<StackExchangeData>(Configuration.GetSection("StackExchangeData"));
            services.Configure<MongoOptions>(Configuration.GetSection("MongoOptions"));

            services.AddAutoMapper(typeof(StackExchangePostProfile).Assembly);
            Ioc.ConfigureServices(services);

            var sp = services.BuildServiceProvider();

            var connection = sp.GetRequiredService<IOptions<EFConnection>>();

            services.AddDbContext<StackExchangeDbContext>(options =>
                options.UseSqlServer(connection.Value.ConnectionString));

            return sp;
        }

        public IConfiguration Configuration { get; }
        public SerilogLoggerFactory SerilogLoggerFactory { get; }
    }
}