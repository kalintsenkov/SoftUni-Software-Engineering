namespace AnimalCentre.Core
{
    using System;

    using Commands.Contracts;
    using Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private const string EndCommand = "End";

        private readonly IAnimalCentre animalCentre;

        private readonly ICommandParser commandParser;

        private readonly IDataReader dataReader;
        private readonly IDataWriter dataWriter;

        public Engine(
            IAnimalCentre animalCentre,
            ICommandParser commandParser,
            IDataReader dataReader,
            IDataWriter dataWriter)
        {
            this.animalCentre = animalCentre;
            this.commandParser = commandParser;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            var input = this.dataReader.ReadLine();

            while (input != EndCommand)
            {
                try
                {
                    this.ExecuteCommands(input);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }

                input = this.dataReader.ReadLine();
            }

            var adoptedAnimals = this.animalCentre.GetAdoptedAnimals();

            this.dataWriter.WriteLine(adoptedAnimals);
        }

        private void ExecuteCommands(string input)
        {
            var command = this.commandParser.Parse(input);

            var message = string.Empty;

            if (command.Name == "RegisterAnimal")
            {
                var type = command.Arguments[0];
                var name = command.Arguments[1];
                var energy = int.Parse(command.Arguments[2]);
                var happiness = int.Parse(command.Arguments[3]);
                var procedureTime = int.Parse(command.Arguments[4]);

                message = this.animalCentre
                    .RegisterAnimal(type, name, energy, happiness, procedureTime);
            }
            else if (command.Name == "Chip")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.Chip(name, procedureTime);
            }
            else if (command.Name == "Vaccinate")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.Vaccinate(name, procedureTime);
            }
            else if (command.Name == "Fitness")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.Fitness(name, procedureTime);
            }
            else if (command.Name == "Play")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.Play(name, procedureTime);
            }
            else if (command.Name == "DentalCare")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.DentalCare(name, procedureTime);
            }
            else if (command.Name == "NailTrim")
            {
                var name = command.Arguments[0];
                var procedureTime = int.Parse(command.Arguments[1]);

                message = this.animalCentre.NailTrim(name, procedureTime);
            }
            else if (command.Name == "Adopt")
            {
                var animalName = command.Arguments[0];
                var owner = command.Arguments[1];

                message = this.animalCentre.Adopt(animalName, owner);
            }
            else if (command.Name == "History")
            {
                var procedureType = command.Arguments[0];

                message = this.animalCentre.History(procedureType);
            }

            this.dataWriter.WriteLine(message);
        }
    }
}
