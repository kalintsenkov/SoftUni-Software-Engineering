namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmployeesProjects = new HashSet<EmployeeProject>();
            InverseManager = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string JobTitle { get; set; }

        public int DepartmentId { get; set; }

        public int? ManagerId { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }

        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
