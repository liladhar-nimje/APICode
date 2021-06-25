using System;
using System.Collections.Generic;

#nullable disable

namespace PatientsApi.Models
{
    public partial class IndustryStandard
    {
        public int IndustryStandardId { get; set; }
        public string Bits { get; set; }
        public string Scenario { get; set; }
        public string Action { get; set; }
    }
}
