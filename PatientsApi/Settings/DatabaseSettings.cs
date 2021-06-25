using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Settings
{
    public class DatabaseSettings
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
