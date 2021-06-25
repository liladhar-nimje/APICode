using Microsoft.Extensions.Options;
using PatientsApi.Models;
using PatientsApi.Repositories.EntityFramework;
using PatientsApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly IOptions<DatabaseSettings> databaseSettings;
        private readonly IMqDbContext mqDbContext;

        public PatientsRepository(
            IOptions<DatabaseSettings> databaseSettings,
            IMqDbContext mqDbContext)
        {
            this.databaseSettings = databaseSettings;
            this.mqDbContext = mqDbContext;
        }

        public List<DefaultRate> GetDefaultRates()
        {
            return mqDbContext.DefaultRate.ToList();
        }
    }
}
