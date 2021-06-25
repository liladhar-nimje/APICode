using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PatientsApi.Repositories.EntityFramework;
using PatientsApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private DatabaseSettings databaseSettings;

        public Startup(
            IConfiguration configuration, 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers();

            services
                .AddConfigurationServices(
                    this.configuration,
                    out this.databaseSettings)
                .AddRouting(options => options.LowercaseUrls = true)
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddHttpContextAccessor()
                .AddScoped(x => x
                    .GetRequiredService<IUrlHelperFactory>()
                    .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext))
                .AddEntityFrameworkSqlServer()
                .AddDbContextPool<MqDbContext>(
                    options => options
                        .UseSqlServer(
                            this.databaseSettings.ConnectionString,
                            x => x.EnableRetryOnFailure())
                        .EnableSensitiveDataLogging(this.hostingEnvironment.IsDevelopment())
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking))
                .AddCommandServices()
                .AddRepositoryServices();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
