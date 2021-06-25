using Microsoft.AspNetCore.Mvc;
using PatientsApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Commands
{
    public interface IPatientsCommand
    {
        IActionResult GetDefaultRates();
    }
}
