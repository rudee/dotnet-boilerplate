using System;
using System.IO.Compression;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore;
using DotnetBoilerplate.Presentation.Web.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace DotnetBoilerplate.Presentation.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration,
                       IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env          = env;
        }



        public IConfiguration Configuration { get; }

        private IWebHostEnvironment _env { get; }

        private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static readonly ILoggerFactory consoleLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Logging
            services.AddLogging(builder => {
                builder.AddConsole();
            });

            // Response Compression
            services.AddResponseCompression();
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            // CORS
            string[] allowedCorsOrigins = Configuration["allowedCorsOrigins"].Split(";", StringSplitOptions.RemoveEmptyEntries);
            services.AddCors(options =>
            {
                options.AddPolicy(
                    _myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(allowedCorsOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                );
            });


            // Database Connection
            services.AddDbContext<IdentityDbContext>(builder => {
                builder.UseSqlServer(Configuration.GetConnectionString("Identity"));
                if (_env.IsLocal())
                {
                    builder.UseLoggerFactory(consoleLoggerFactory);
                    builder.EnableSensitiveDataLogging();
                    builder.EnableDetailedErrors();
                }
            });

            // Dependency Injection
            services.AddDependencyInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {
            logger.LogInformation($"Configuring for '{env.EnvironmentName}' environment");
            if (env.IsDevelopment() || env.IsLocal())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseResponseCompression();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseCors(_myAllowSpecificOrigins);
            //app.UseAuthentication();
        }
    }
}
