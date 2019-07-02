namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new List<Doctor>();
            this.Departments = new List<Department>();
        }

        public List<Doctor> Doctors { get; set; }

        public List<Department> Departments { get; set; }

        public void AddDoctor(string firstName, string lastName)
        {
            if (!this.Doctors.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                var doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string departmentName)
        {
            if (!this.Departments.Any(x => x.Name == departmentName))
            {
                var department = new Department(departmentName);
                this.Departments.Add(department);
            }
        }

        public void AddPatient(string doctorName, string departmentName, string patientName)
        {
            var doctor = this.Doctors.FirstOrDefault(x => x.FullName == doctorName);
            var department = this.Departments.FirstOrDefault(x => x.Name == departmentName);

            var patient = new Patient(patientName);

            doctor.Patients.Add(patient);
            department.AddPatientInRoom(patient);
        }
    }
}
