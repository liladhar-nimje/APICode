using PatientsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Repositories
{
    public interface IPatientsRepository
    {
        List<DefaultRate> GetDefaultRates();
    }
}
