using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PatientsApi.Models;
using System;

namespace PatientsApi.Repositories.EntityFramework
{
    public interface IMqDbContext : IInfrastructure<IServiceProvider>, IDisposable
    {
        DbSet<Patient> Patient { get; set; }

        DbSet<HealthDetail> HealthDetail { get; set; }

        DbSet<SuggestedAction> SuggestedAction { get; set; }

        DbSet<DefaultRate> DefaultRate { get; set; }

        DbSet<IndustryStandard> IndustryStandard { get; set; }
    }
}
