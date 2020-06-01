using System;
using System.IO.Compression;
using Dnb.Identity.Infrastructure.Repositories.EFCore;
using Dnb.Presentation.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dnb.Presentation.WebApi
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        private IWebHostEnvironment _env { get; }

        private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static readonly ILoggerFactory consoleLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public Startup(IConfiguration      configuration,
                       IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env           = env;
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Logging
            services.AddLogging();

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
            string[] allowedCorsOrigins = _configuration["allowedCorsOrigins"].Split(";", StringSplitOptions.RemoveEmptyEntries);
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
            services.AddDbContext<Identity.Infrastructure.Repositories.EFCore.DbContext>(builder => {
                builder.UseSqlServer(_configuration.GetConnectionString("Identity"));
                if (_env.IsDevelopment())
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
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
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
