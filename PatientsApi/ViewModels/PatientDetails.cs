namespace PatientsApi.ViewModels
{
    public class PatientDetails
    {
        public int? PatientId { get; set; }

        public string PatientName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int OxygenLevel { get; set; }

        public int HeartRate { get; set; }

        public int RespiratoryRate { get; set; }
    }
}
