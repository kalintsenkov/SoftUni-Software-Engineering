using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < peopleCount; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestMan = family.GetOldestMember();

            Console.WriteLine($"{oldestMan.Name} {oldestMan.Age}");
        }
    }
}
