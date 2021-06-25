using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PatientsApi.Commands;
using PatientsApi.Repositories;
using PatientsApi.Repositories.EntityFramework;
using PatientsApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationServices(
           this IServiceCollection services,
           IConfiguration configuration,
           out DatabaseSettings databaseSettings)
        {
            services
                .AddSingleton(configuration)
                .Configure<AppSettings>(configuration)
                .Configure<DatabaseSettings>(configuration.GetSection(nameof(AppSettings.ConnectionStrings)));

            databaseSettings = services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<DatabaseSettings>>()
                .Value;

            AppSettings.Current = new AppSettings();
            configuration.Bind(AppSettings.Current);
            return services;
        }

        public static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IPatientsCommand, PatientsCommand>();
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services) =>
            services
                .AddScoped<IMqDbContext, MqDbContext>()
                .AddScoped<IPatientsRepository, PatientsRepository>();
    }
}
