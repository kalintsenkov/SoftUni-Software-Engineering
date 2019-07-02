namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
            => this.FirstName + " " + this.LastName;

        public List<Patient> Patients { get; set; }

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
