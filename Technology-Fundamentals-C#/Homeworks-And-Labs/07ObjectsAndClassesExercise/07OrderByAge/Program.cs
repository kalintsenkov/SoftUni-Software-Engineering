using System;
using System.Collections.Generic;
using System.Linq;

namespace _07OrderByAge
{
    public class Human
    {
        public Human(string name, int id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var people = new List<Human>();

            while (input != "End")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = tokens[0];
                int id = int.Parse(tokens[1]);
                int age = int.Parse(tokens[2]);

                people.Add(new Human(name, id, age));

                input = Console.ReadLine();
            }

            foreach (var human in people.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{human.Name} with ID: {human.Id} is {human.Age} years old.");
            }
        }
    }
}
