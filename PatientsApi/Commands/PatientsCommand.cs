using Microsoft.AspNetCore.Mvc;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using PatientsApi.Models;
using PatientsApi.Repositories;
using PatientsApi.ViewModels;
using QuantumSample.QB4;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatientsApi.Commands
{
    public class PatientsCommand : IPatientsCommand
    {
        private readonly IPatientsRepository repository;

        public PatientsCommand(IPatientsRepository patientsRepository) => this.repository = patientsRepository;

        public IActionResult GetDefaultRates()
        {
            return new OkObjectResult(repository.GetDefaultRates());
        }

        public IActionResult GetPatientInfo(string name)
        {
            var patient = repository.GetByName(name);

            var healthDetail = repository.GetHealthDetail(patient.PatientId);

            var suggestedAction = repository.GetSuggestedAction(healthDetail.HealthDetailId);

            var patientInfo = new PatientInfo 
            { 
                PatientId = patient.PatientId,
                PatientName = patient.Name,
                Priority = suggestedAction.Priority,
                Actions = suggestedAction.Action
            };

            return new OkObjectResult(patientInfo);
        }

        public async Task<IActionResult> PostPatientDataAsync(PatientDetails patientDetails)
        {
            try
            {
                Patient patient = GetPatient(patientDetails);
                var healthDetail = new HealthDetail();

                var bitOne = this.GetOxygenBit(patientDetails.OxygenLevel);
                var heartTuple = this.GetHeartBits(patientDetails.HeartRate);
                var respiratoryTuple = this.GetRespiratoryBits(patientDetails.RespiratoryRate);

                if (patient != null)
                {
                    healthDetail.PatientId = patient.PatientId;
                    healthDetail.HeartRate = patientDetails.HeartRate;
                    healthDetail.OxygenLevel = patientDetails.OxygenLevel;
                    healthDetail.RespiratoryRate = patientDetails.RespiratoryRate;
                    repository.SavePatientHealthDetail(healthDetail);
                }

                using var simulator = new QuantumSimulator();
                string output = await QB4Run.Run(
                    simulator, bitOne,
                    heartTuple.Item1, heartTuple.Item2,
                    respiratoryTuple.Item1, respiratoryTuple.Item2);

                var bits = string.Concat(
                    respiratoryTuple.Item2, respiratoryTuple.Item1,
                    heartTuple.Item2, heartTuple.Item1,
                    bitOne);

                if (output == Constants.Constants.Priority1
                    || output == Constants.Constants.Priority2)
                {
                    var industryStandard = repository.GetIndustryStandard(bits);
                    if (industryStandard != null)
                    {
                        var actionTuple = this.GetActionsValue(industryStandard.Scenario);
                        var action = industryStandard.Action.Replace("#X", actionTuple.Item1.ToString());
                        action = action.Replace("#Y", actionTuple.Item2.ToString());

                        repository.SaveSuggestedAction(new SuggestedAction
                        {
                            Action = action,
                            HealthDetailId = healthDetail.HealthDetailId,
                            Priority = output,
                        });
                    }
                }

                return new OkObjectResult(output);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Patient GetPatient(PatientDetails patientDetails)
        {
            Patient patient = repository.GetByName(patientDetails.PatientName);
            if (patient == null)
            {
                var newPatient = new Patient
                {
                    Name = patientDetails.PatientName,
                    Age = patientDetails.Age,
                    Address = patientDetails.Address
                };

                repository.SavePatient(newPatient);
                return newPatient;
            }

            return patient;
        }

        private int GetOxygenBit(int oxygenLevel)
        {
            var oxygenDefaulRate = this.repository.GetDefaultRate(Constants.Constants.OxygenLevel);

            if (oxygenLevel >= oxygenDefaulRate.Min && oxygenLevel <= oxygenDefaulRate.Max)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private Tuple<int, int> GetHeartBits(int heartRate)
        {
            int bitOne, bitTwo;
            var heartDefaulRate = this.repository.GetDefaultRate(Constants.Constants.HeartRate);

            if (heartRate >= heartDefaulRate.Min && heartRate <= heartDefaulRate.Max)
            {
                bitOne = 0;
            }
            else
            {
                bitOne = 1;
            }

            if (heartRate > heartDefaulRate.Max)
            {
                bitTwo = 0;
            }
            else if (heartRate < heartDefaulRate.Min)
            {
                bitTwo = 1;
            }
            else
            {
                bitTwo = 0;
            }

            return new Tuple<int, int>(bitOne, bitTwo);
        }

        private Tuple<int, int> GetRespiratoryBits(int respiratoryRate)
        {
            int bitOne, bitTwo;
            var respiratoryDefaulRate = this.repository.GetDefaultRate(Constants.Constants.RespiratoryRate);

            if (respiratoryRate >= respiratoryDefaulRate.Min && respiratoryRate <= respiratoryDefaulRate.Max)
            {
                bitOne = 0;
            }
            else
            {
                bitOne = 1;
            }

            if (respiratoryRate > respiratoryDefaulRate.Max)
            {
                bitTwo = 0;
            }
            else if (respiratoryRate < respiratoryDefaulRate.Min)
            {
                bitTwo = 1;
            }
            else
            {
                bitTwo = 0;
            }

            return new Tuple<int, int>(bitOne, bitTwo);
        }

        private Tuple<int, int> GetActionsValue(string scenario)
        {
            int lowCount = 0, highCount = 0;
            foreach (Match m in Regex.Matches(scenario, "Low"))
            {
                lowCount++;
            }

            foreach (Match m in Regex.Matches(scenario, "High"))
            {
                highCount++;
            }

            var x = Math.Abs((lowCount * 5) + (highCount * (-3)));
            Random random = new Random();
            var y = random.Next(8, 20);

            return new Tuple<int, int>(x, y);
        }
    }
}
