using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PatientsApi.Models;

namespace PatientsApi.Repositories.EntityFramework
{
    public class MqDbContext : DbContext, IMqDbContext
    {
        public MqDbContext(DbContextOptions<MqDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<HealthDetail> HealthDetail { get; set; }

        public DbSet<SuggestedAction> SuggestedAction { get; set; }

        public DbSet<DefaultRate> DefaultRate { get; set; }

        public DbSet<IndustryStandard> IndustryStandard { get; set; }

        public IDbContextTransaction BeginTransaction() => this.Database.BeginTransaction();

        public void CommitTransaction() => this.Database.CommitTransaction();

        public void RollbackTransaction() => this.Database.RollbackTransaction();
    }
}
