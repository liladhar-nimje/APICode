using System;
using System.Collections.Generic;

#nullable disable

namespace PatientsApi.Models
{
    public partial class DefaultRate
    {
        public int DefaultRateId { get; set; }
        public string Type { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
    }
}
