namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        private readonly IController controller;

        public Engine(
            IWriter writer,
            IReader reader,
            IController controller)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine()
                    .Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    var message = this.ExecuteCommand(input);

                    this.writer.WriteLine(message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
            }
        }

        private string ExecuteCommand(string[] input)
        {
            var message = string.Empty;

            var commandName = input[0];

            if (commandName == "AddAstronaut")
            {
                var astronautType = input[1];
                var astronautName = input[2];

                message = this.controller.AddAstronaut(astronautType, astronautName);
            }
            else if (commandName == "AddPlanet")
            {
                var planetName = input[1];
                var items = input
                    .Skip(2)
                    .ToArray();

                message = this.controller.AddPlanet(planetName, items);
            }
            else if (commandName == "RetireAstronaut")
            {
                var astronautName = input[1];

                message = this.controller.RetireAstronaut(astronautName);
            }
            else if (commandName == "ExplorePlanet")
            {
                var planetName = input[1];

                message = this.controller.ExplorePlanet(planetName);
            }
            else if (commandName == "Report")
            {
                message = this.controller.Report();
            }

            return message;
        }
    }
}
