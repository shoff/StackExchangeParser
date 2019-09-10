namespace StackExchangeParser
{
    using System;
    using AutoMapper;
    using Configuration;
    using Configuration.TypeConverters;
    using Domain.Configuration;

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
#pragma warning disable 618
            SerilogLoggerFactory serilogLoggerFactory)
#pragma warning restore 618
        {
            this.Configuration = configuration;
            this.SerilogLoggerFactory = serilogLoggerFactory;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                .AddSingleton(factory => this.SerilogLoggerFactory)
                .AddLogging(configure => configure.AddSerilog())
                .Configure<EFConnection>(Configuration.GetSection("EFConnection"))
                .Configure<StackExchangeData>(Configuration.GetSection("StackExchangeData"))
                .Configure<MongoOptions>(Configuration.GetSection("MongoOptions"))
                .AddAutoMapper(typeof(StackExchangePostProfile).Assembly)
                .ConfigureServices();

            var sp = services.BuildServiceProvider();

            return sp;
        }

        public IConfiguration Configuration { get; }
#pragma warning disable 618
        public SerilogLoggerFactory SerilogLoggerFactory { get; }
#pragma warning restore 618
    }
}