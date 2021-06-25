using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsApi.Settings
{
    public class AppSettings
    {
        [Required]
        public static AppSettings Current { get; set; }

        [Required]
        public DatabaseSettings ConnectionStrings { get; set; }
    }
}
