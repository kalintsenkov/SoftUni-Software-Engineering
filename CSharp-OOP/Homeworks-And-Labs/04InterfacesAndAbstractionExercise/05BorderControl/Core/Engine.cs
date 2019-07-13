namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;

        public Engine()
        {
            this.identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputParts = input
                    .Split()
                    .ToArray();

                if (inputParts.Length == 2)
                {
                    this.AddRobot(inputParts);
                }
                else if (inputParts.Length == 3)
                {
                    this.AddCitizen(inputParts);
                }

                input = Console.ReadLine();
            }

            var fakeIdDigits = Console.ReadLine();

            foreach (var identifiable in this.identifiables.Where(x => x.Id.EndsWith(fakeIdDigits)))
            {
                Console.WriteLine(identifiable);
            }
        }

        private void AddCitizen(string[] inputParts)
        {
            var citizenName = inputParts[0];
            var age = int.Parse(inputParts[1]);
            var id = inputParts[2];

            IIdentifiable citizen = new Citizen(citizenName, age, id);
            this.identifiables.Add(citizen);
        }

        private void AddRobot(string[] inputParts)
        {
            var model = inputParts[0];
            var id = inputParts[1];

            IIdentifiable robot = new Robot(model, id);
            this.identifiables.Add(robot);
        }
    }
}
