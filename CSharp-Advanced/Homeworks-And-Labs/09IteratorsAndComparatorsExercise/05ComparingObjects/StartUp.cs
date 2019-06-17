using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var personInfo = input.Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                var person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            int equalPeopleCount = 0;
            int notEqualPeopleCount = 0;

            var targetPerson = people[personIndex];

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0)
                {
                    equalPeopleCount++;
                }
                else
                {
                    notEqualPeopleCount++;
                }
            }

            if (equalPeopleCount > 1)
            {
                Console.WriteLine($"{equalPeopleCount} {notEqualPeopleCount} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
