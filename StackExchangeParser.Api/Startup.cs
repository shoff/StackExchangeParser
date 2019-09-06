using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StackExchangeParser.Api
{
    using System.IO;
    using Configuration;
    using Elasticsearch.Configuration;
    using Infrastructure.Queries;
    using MediatR;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                .AddLogging(configure => configure.AddSerilog())
                .AddMediatR(typeof(QueryHandler).Assembly)
                .Configure<IOptions<ElasticSearch>>(this.Configuration.GetSection("ElasticSearch"))
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.AllowAnyOrigin();
                            builder.AllowAnyMethod();
                            builder.AllowAnyHeader();
                        });
                })
                .AddMvc(options => { options.EnableEndpointRouting = true; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.VerifyOptions();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API"
                });
            });

            services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin()
                .WithMethods("GET", "POST", "PUT"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                //app.UseHsts();
                //app.UseHttpsRedirection();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                //c.RoutePrefix = "";
            });
            app.UseMvc();
        }
    }
}

