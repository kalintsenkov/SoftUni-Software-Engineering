using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                people.Add(person);
            }

            var result = people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
