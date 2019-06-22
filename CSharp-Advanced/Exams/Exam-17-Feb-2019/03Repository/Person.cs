namespace Repository
{
    using System;

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate  { get; set; }

        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }
    }
}
