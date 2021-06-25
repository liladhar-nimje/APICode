using Microsoft.AspNetCore.Mvc;
using PatientsApi.Repositories;

namespace PatientsApi.Commands
{
    public class PatientsCommand : IPatientsCommand
    {
        private readonly IPatientsRepository patientsRepository;

        public PatientsCommand(IPatientsRepository patientsRepository) => this.patientsRepository = patientsRepository;

        public IActionResult GetDefaultRates()
        {
            return new OkObjectResult(patientsRepository.GetDefaultRates());
        }
    }
}
