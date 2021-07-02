using System;
using System.Collections.Generic;

#nullable disable

namespace PatientsApi.Models
{
    public partial class SuggestedAction
    {
        public int SuggestedActionId { get; set; }
        public int HealthDetailId { get; set; }
        public string Action { get; set; }
        public string Priority { get; set; }

        public virtual HealthDetail HealthDetail { get; set; }
    }
}
