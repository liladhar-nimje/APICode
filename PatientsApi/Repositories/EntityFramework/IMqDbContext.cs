using Microsoft.EntityFrameworkCore;
using PatientsApi.Models;

namespace PatientsApi.Repositories.EntityFramework
{
    public interface IMqDbContext
    {
        DbSet<Patient> Patient { get; set; }

        DbSet<HealthDetail> HealthDetail { get; set; }

        DbSet<SuggestedAction> SuggestedAction { get; set; }

        DbSet<DefaultRate> DefaultRate { get; set; }

        DbSet<IndustryStandard> IndustryStandard { get; set; }

        int SaveChanges();
    }
}
