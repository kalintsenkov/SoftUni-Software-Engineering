namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Contracts;
    using Models;

    public class Engine
    {
        private readonly List<IMammal> mammals;
        private readonly List<IIdentifiable> identifiables;

        private CommandParser commandParser;

        public Engine(CommandParser commandParser)
        {
            this.commandParser = commandParser;
            this.mammals = new List<IMammal>();
            this.identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var command = this.commandParser.Parse(input);

                if (command.Name == "Robot")
                {
                    this.AddRobot(command.Arguments);
                }
                else if (command.Name == "Citizen")
                {
                    this.AddCitizen(command.Arguments);
                }
                else if (command.Name == "Pet")
                {
                    this.AddPet(command.Arguments);
                }

                input = Console.ReadLine();
            }

            var targetYear = Console.ReadLine();

            this.PrintMammals(targetYear);
        }

        private void PrintMammals(string targetYear)
        {
            if (this.mammals.Any(x => x.Birthdate.EndsWith(targetYear)))
            {
                foreach (var mammal in this.mammals.Where(x => x.Birthdate.EndsWith(targetYear)))
                {
                    Console.WriteLine(mammal);
                }
            }
        }

        private void AddPet(string[] arguments)
        {
            var petName = arguments[0];
            var birthdate = arguments[1];

            IMammal pet = new Pet(petName, birthdate);
            this.mammals.Add(pet);
        }

        private void AddCitizen(string[] arguments)
        {
            var citizenName = arguments[0];
            var age = int.Parse(arguments[1]);
            var id = arguments[2];
            var birthdate = arguments[3];

            IMammal citizen = new Citizen(citizenName, age, id, birthdate);
            this.mammals.Add(citizen);
        }

        private void AddRobot(string[] arguments)
        {
            var model = arguments[0];
            var id = arguments[1];

            IIdentifiable robot = new Robot(model, id);
            this.identifiables.Add(robot);
        }
    }
}
