using PatientsApi.Models;
using System.Collections.Generic;

namespace PatientsApi.Repositories
{
    public interface IPatientsRepository
    {
        List<DefaultRate> GetDefaultRates();

        DefaultRate GetDefaultRate(string type);

        Patient SavePatient(Patient patient);

        Patient Get(int patientId);

        Patient GetByName(string name);


        IndustryStandard GetIndustryStandard(string bits);

        List<Patient> GetAll();

        HealthDetail SavePatientHealthDetail(HealthDetail healthDetail);

        SuggestedAction SaveSuggestedAction(SuggestedAction suggestedAction);

        HealthDetail GetHealthDetail(int patientId);

        SuggestedAction GetSuggestedAction(int healthDetailId);
    }
}
