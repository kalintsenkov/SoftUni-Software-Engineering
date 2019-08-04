namespace MXGP.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private const string EndCommand = "End";

        private readonly IChampionshipController championshipController;

        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Engine(
            IChampionshipController championshipController,
            IReader dataReader,
            IWriter dataWriter)
        {
            this.championshipController = championshipController;
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
                    var message = this.ExecuteCommands(input);
                    this.dataWriter.WriteLine(message);
                }
                catch (ArgumentException ae)
                {
                    this.dataWriter.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.dataWriter.WriteLine(ioe.Message);
                }

                input = this.dataReader.ReadLine();
            }
        }

        private string ExecuteCommands(string input)
        {
            var inputParts = input.Split();

            var commandName = inputParts[0];

            var message = string.Empty;

            if (commandName == "CreateRider")
            {
                var name = inputParts[1];

                message = this.championshipController.CreateRider(name);
            }
            else if (commandName == "CreateMotorcycle")
            {
                var type = inputParts[1];
                var model = inputParts[2];
                var horsePower = int.Parse(inputParts[3]);

                message = this.championshipController.CreateMotorcycle(type, model, horsePower);
            }
            else if (commandName == "AddMotorcycleToRider")
            {
                var riderName = inputParts[1];
                var motorcycleName = inputParts[2];

                message = this.championshipController.AddMotorcycleToRider(riderName, motorcycleName);
            }
            else if (commandName == "AddRiderToRace")
            {
                var raceName = inputParts[1];
                var riderName = inputParts[2];

                message = this.championshipController.AddRiderToRace(raceName, riderName);
            }
            else if (commandName == "CreateRace")
            {
                var name = inputParts[1];
                var laps = int.Parse(inputParts[2]);

                message = this.championshipController.CreateRace(name, laps);
            }
            else if (commandName == "StartRace")
            {
                var raceName = inputParts[1];

                message = this.championshipController.StartRace(raceName);
            }

            return message;
        }
    }
}
