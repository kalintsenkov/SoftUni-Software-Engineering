namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(
            string firstName,
            string lastName,
            int age,
            decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                ValidateName(value, "First name");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                ValidateName(value, "Last name");

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                ValidateAge(value);

                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;

            private set
            {
                ValidateSalary(value);

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * (percentage / 100) / 2;
            }
            else
            {
                this.Salary += this.Salary * percentage / 100;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} gets {this.Salary:F2} leva.";
        }

        private static void ValidateName(string name, string targetName)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException($"{targetName} cannot contain fewer than 3 symbols!");
            }
        }

        private static void ValidateAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }

        private static void ValidateSalary(decimal salary)
        {
            if (salary < 460M)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
        }
    }
}
