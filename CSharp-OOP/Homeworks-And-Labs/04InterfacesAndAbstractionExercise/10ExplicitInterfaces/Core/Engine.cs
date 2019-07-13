namespace ExplicitInterfaces.Core
{
    using System;
    using Contracts;
    using Models;

    public class Engine
    {
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputParts = input.Split();

                var name = inputParts[0];
                var country = inputParts[1];
                var age = int.Parse(inputParts[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
