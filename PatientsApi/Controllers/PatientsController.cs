using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientsApi.Commands;
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
        public IActionResult GetDefaultRates(
            [FromServices] IPatientsCommand command) =>
            command.GetDefaultRates();
    }
}
