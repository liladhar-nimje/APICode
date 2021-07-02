using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientsApi.Commands;
using PatientsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(ILogger<PatientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPatientInfo(
            [FromServices] IPatientsCommand command,
            [FromQuery] string name) =>
            command.GetPatientInfo(name);

        [HttpPost]
        public Task<IActionResult> Post(
            [FromBody] PatientDetails patientDetails,
            [FromServices] IPatientsCommand command) =>
            command.PostPatientDataAsync(patientDetails);
    }
}
