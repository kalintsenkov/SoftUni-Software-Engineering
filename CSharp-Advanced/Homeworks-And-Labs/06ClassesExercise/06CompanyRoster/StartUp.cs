using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();
            var departments = new HashSet<string>();

            for (int i = 0; i < employeesCount; i++)
            {
                var employeeInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string position = employeeInfo[2];
                string department = employeeInfo[3];

                if (employeeInfo.Length == 4)
                {
                    employees.Add(new Employee(name, salary, position, department, @"n/a", -1));
                }
                else if (employeeInfo.Length == 5)
                {
                    string ageOrEmail = employeeInfo[4];

                    if (ageOrEmail.Contains("@"))
                    {
                        employees.Add(new Employee(name, salary, position, department, ageOrEmail, -1));
                    }
                    else
                    {
                        int age = int.Parse(ageOrEmail);

                        employees.Add(new Employee(name, salary, position, department, @"n/a", age));
                    }
                }
                else if (employeeInfo.Length == 6)
                {
                    string email = employeeInfo[4];
                    int age = int.Parse(employeeInfo[5]);
                    employees.Add(new Employee(name, salary, position, department, email, age));
                }

                departments.Add(department);
            }

            string bestDepartment = GetBestDepartment(departments, employees);

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (var employee in employees.Where(x => x.Department == bestDepartment).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }

        public static string GetBestDepartment(HashSet<string> departments, List<Employee> employees)
        {
            string bestDepartment = string.Empty;
            double bestSalary = double.MinValue;

            foreach (var department in departments)
            {
                double average = employees
                    .Where(x => x.Department == department)
                    .Select(x => x.Salary)
                    .Average();

                if (average > bestSalary)
                {
                    bestSalary = average;
                    bestDepartment = department;
                }
            }

            return bestDepartment;
        }
    }
}
