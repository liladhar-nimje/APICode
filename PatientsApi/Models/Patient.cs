using System;
using System.Collections.Generic;

#nullable disable

namespace PatientsApi.Models
{
    public partial class Patient
    {
        public Patient()
        {
            HealthDetails = new HashSet<HealthDetail>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public virtual ICollection<HealthDetail> HealthDetails { get; set; }
    }
}
