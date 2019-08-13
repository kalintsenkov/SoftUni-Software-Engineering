namespace ViceCity.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IController controller;

        public Engine(
            IReader reader,
            IWriter writer,
            IController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            var input = this.reader.ReadLine();

            while (input != "Exit")
            {
                try
                {
                    var message = this.ExecuteCommand(input);

                    this.writer.WriteLine(message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }

                input = this.reader.ReadLine();
            }
        }

        private string ExecuteCommand(string input)
        {
            var inputParts = input.Split();

            var commandName = inputParts[0];

            var message = string.Empty;

            if (commandName == "AddPlayer")
            {
                var name = inputParts[1];

                message = this.controller.AddPlayer(name);
            }
            else if (commandName == "AddGun")
            {
                var gunType = inputParts[1];
                var gunName = inputParts[2];

                message = this.controller.AddGun(gunType, gunName);
            }
            else if (commandName == "AddGunToPlayer")
            {
                var name = inputParts[1];

                message = this.controller.AddGunToPlayer(name);
            }
            else if (commandName == "Fight")
            {
                message = this.controller.Fight();
            }

            return message;
        }
    }
}
