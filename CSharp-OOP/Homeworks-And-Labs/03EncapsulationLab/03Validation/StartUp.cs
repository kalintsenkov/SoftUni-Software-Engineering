namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();

                    var firstName = cmdArgs[0];
                    var lastName = cmdArgs[1];
                    var age = int.Parse(cmdArgs[2]);
                    var salary = decimal.Parse(cmdArgs[3]);

                    var person = new Person(firstName, lastName, age, salary);

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            var parcentage = decimal.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(Console.WriteLine);
        }
    }
}