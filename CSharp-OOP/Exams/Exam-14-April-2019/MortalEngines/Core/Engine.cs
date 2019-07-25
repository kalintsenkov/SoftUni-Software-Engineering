namespace MortalEngines.Core
{
    using System;

    using Commands.Contracts;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private const string EndCommand = "Quit";

        private readonly IMachinesManager machinesManager;

        private readonly ICommandParser commandParser;

        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Engine(
            IMachinesManager machinesManager,
            ICommandParser commandParser,
            IReader dataReader,
            IWriter dataWriter)
        {
            this.machinesManager = machinesManager;
            this.commandParser = commandParser;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            var input = this.dataReader.Read();

            while (input != EndCommand)
            {
                try
                {
                    this.ExecuteCommands(input);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine($"Error: {ane.Message}");
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine($"Error: {nre.Message}");
                }

                input = this.dataReader.Read();
            }
        }

        private void ExecuteCommands(string input)
        {
            var command = this.commandParser.Parse(input);

            var message = string.Empty;

            var name = command.Arguments[0];

            if (command.Name == "HirePilot")
            {
                message = this.machinesManager.HirePilot(name);
            }
            else if (command.Name == "PilotReport")
            {
                message = this.machinesManager.PilotReport(name);
            }
            else if (command.Name == "ManufactureTank")
            {
                var attack = double.Parse(command.Arguments[1]);
                var defense = double.Parse(command.Arguments[2]);

                message = this.machinesManager.ManufactureTank(name, attack, defense);
            }
            else if (command.Name == "ManufactureFighter")
            {
                var attack = double.Parse(command.Arguments[1]);
                var defense = double.Parse(command.Arguments[2]);

                message = this.machinesManager.ManufactureFighter(name, attack, defense);
            }
            else if (command.Name == "MachineReport")
            {
                message = this.machinesManager.MachineReport(name);
            }
            else if (command.Name == "AggressiveMode")
            {
                message = this.machinesManager.ToggleFighterAggressiveMode(name);
            }
            else if (command.Name == "DefenseMode")
            {
                message = this.machinesManager.ToggleTankDefenseMode(name);
            }
            else if (command.Name == "Engage")
            {
                var machineName = command.Arguments[1];

                message = this.machinesManager.EngageMachine(name, machineName);
            }
            else if (command.Name == "Attack")
            {
                var defendingMachineName = command.Arguments[1];

                message = this.machinesManager.AttackMachines(name, defendingMachineName);
            }

            this.dataWriter.Write(message);
        }
    }
}
