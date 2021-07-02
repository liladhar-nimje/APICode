using Microsoft.AspNetCore.Mvc;
using PatientsApi.ViewModels;
using System.Threading.Tasks;

namespace PatientsApi.Commands
{
    public interface IPatientsCommand
    {
        IActionResult GetDefaultRates();

        IActionResult GetPatientInfo(string name);

        Task<IActionResult> PostPatientDataAsync(PatientDetails patientDetails);
    }
}
