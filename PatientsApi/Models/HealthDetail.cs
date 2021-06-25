using System;
using System.Collections.Generic;

#nullable disable

namespace PatientsApi.Models
{
    public partial class HealthDetail
    {
        public HealthDetail()
        {
            SuggestedActions = new HashSet<SuggestedAction>();
        }

        public int HealthDetailId { get; set; }
        public int PatientId { get; set; }
        public int OxygenLevel { get; set; }
        public int HeartRate { get; set; }
        public int RespiratoryRate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<SuggestedAction> SuggestedActions { get; set; }
    }
}
