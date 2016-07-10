using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GuildManagement.Business;
using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using Microsoft.Data.Entity;
using Newtonsoft.Json.Serialization;

namespace GuildManagement
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"config.json", optional: true)
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            builder.AddUserSecrets();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<GuildManagementContext>(options =>
                        options.UseSqlServer(Configuration.Get<string>("Data:GuildManagementConnection:ConnectionString")));

            services.AddSingleton<IConfiguration>(sp => { return Configuration; });

            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IGuildRepository, GuildRepository>();
            services.AddScoped<IBlizzardSyncRepository, BlizzardSyncRepository>();

            services.AddTransient<IBlizzardConnectionRepository, BlizzardConnectionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }

        // Source: https://github.com/aspnet/MusicStore/blob/master/src/MusicStore/Startup.cs
        //This method is invoked when ASPNET_ENV is 'Development' or is not defined
        //The allowed values are Development,Staging and Production
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Information);

            // Display custom error page in production when error occurs
            // During development use the ErrorPage middleware to display error information in the browser
            app.UseDeveloperExceptionPage();

            app.UseDatabaseErrorPage();

            Configure(app, env, loggerFactory);
        }

        //This method is invoked when ASPNET_ENV is 'Staging'
        //The allowed values are Development,Staging and Production
        public void ConfigureStaging(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Warning);

            // StatusCode pages to gracefully handle status codes 400-599.
            app.UseStatusCodePages();
            //app.UseStatusCodePagesWithRedirects("~/Home/StatusCodePage");

            app.UseDeveloperExceptionPage();
            //app.UseExceptionHandler("/Home/Error");

            Configure(app, env, loggerFactory);
        }

        //This method is invoked when ASPNET_ENV is 'Production'
        //The allowed values are Development,Staging and Production
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Warning);

            // StatusCode pages to gracefully handle status codes 400-599.
            app.UseStatusCodePages();
            //app.UseStatusCodePagesWithRedirects("~/Home/StatusCodePage");

            app.UseDeveloperExceptionPage();
            //app.UseExceptionHandler("/Home/Error");

            Configure(app, env, loggerFactory);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
