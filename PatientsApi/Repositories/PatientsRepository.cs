using Microsoft.Extensions.Options;
using PatientsApi.Models;
using PatientsApi.Repositories.EntityFramework;
using PatientsApi.Settings;
using System.Collections.Generic;
using System.Linq;

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

        public DefaultRate GetDefaultRate(string type)
        {
            return mqDbContext.DefaultRate
                .First(x => x.Type == type);
        }

        public Patient SavePatient(Patient patient)
        {
            mqDbContext.Patient.Add(patient);
            mqDbContext.SaveChanges();
            return patient;
        }

        public Patient Get(int patientId)
        {
            return mqDbContext.Patient.FirstOrDefault(x => x.PatientId == patientId);
        }

        public Patient GetByName(string name)
        {
            return mqDbContext.Patient.FirstOrDefault(x => x.Name == name);
        }

        public IndustryStandard GetIndustryStandard(string bits)
        {
            return mqDbContext.IndustryStandard.FirstOrDefault(x => x.Bits.Equals(bits));
        }

        public List<Patient> GetAll()
        {
            return mqDbContext.Patient.ToList();
        }

        public HealthDetail SavePatientHealthDetail(HealthDetail healthDetail)
        {
            mqDbContext.HealthDetail.Add(healthDetail);
            mqDbContext.SaveChanges();
            return healthDetail;
        }
        
        public SuggestedAction SaveSuggestedAction(SuggestedAction suggestedAction)
        {
            mqDbContext.SuggestedAction.Add(suggestedAction);
            mqDbContext.SaveChanges();
            return suggestedAction;
        }

        public HealthDetail GetHealthDetail(int patientId)
        {
            return mqDbContext.HealthDetail.Where(x => x.PatientId == patientId).OrderBy(x => x.HealthDetailId).LastOrDefault();
        }

        public SuggestedAction GetSuggestedAction(int healthDetailId)
        {
            return mqDbContext.SuggestedAction.Where(x => x.HealthDetailId == healthDetailId).OrderBy(x => x.SuggestedActionId).LastOrDefault(); ;
        }
    }
}
