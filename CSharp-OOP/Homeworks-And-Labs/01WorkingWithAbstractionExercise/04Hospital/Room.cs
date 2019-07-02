namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; set; }

        public bool IsFull => this.Patients.Count >= 3;

        public void AddPatient(Patient patient)
        {
            if (this.Patients.Count < 3)
            {
                this.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(x => x.Name))
            {
                result.AppendLine(patient.Name);
            }

            return result.ToString().TrimEnd(); 
        }
    }
}