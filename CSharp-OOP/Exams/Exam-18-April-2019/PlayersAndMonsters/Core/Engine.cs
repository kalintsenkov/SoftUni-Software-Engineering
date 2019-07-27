namespace PlayersAndMonsters.Core
{
    using System;

    using Commands.Contracts;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private const string EndCommand = "Exit";

        private readonly ICommandParser commandParser;
        private readonly IManagerController managerController;

        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Engine(
            ICommandParser commandParser,
            IManagerController managerController,
            IReader dataReader,
            IWriter dataWriter)
        {
            this.commandParser = commandParser;
            this.managerController = managerController;
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
                    this.dataWriter.WriteLine(ae.Message);
                }

                input = this.dataReader.ReadLine();
            }
        }

        private void ExecuteCommands(string input)
        {
            var command = this.commandParser.Parse(input);

            var message = string.Empty;

            if (command.Name == "AddPlayer")
            {
                var playerType = command.Arguments[0];
                var playerUsername = command.Arguments[1];

                message = this.managerController.AddPlayer(playerType, playerUsername);
            }
            else if (command.Name == "AddCard")
            {
                var cardType = command.Arguments[0];
                var cardName = command.Arguments[1];

                message = this.managerController.AddCard(cardType, cardName);
            }
            else if (command.Name == "AddPlayerCard")
            {
                var playerUsername = command.Arguments[0];
                var cardName = command.Arguments[1];

                message = this.managerController.AddPlayerCard(playerUsername, cardName);
            }
            else if (command.Name == "Fight")
            {
                var attackUser = command.Arguments[0];
                var enemyUser = command.Arguments[1];

                message = this.managerController.Fight(attackUser, enemyUser);
            }
            else if (command.Name == "Report")
            {
                message = this.managerController.Report();
            }

            this.dataWriter.WriteLine(message);
        }
    }
}
