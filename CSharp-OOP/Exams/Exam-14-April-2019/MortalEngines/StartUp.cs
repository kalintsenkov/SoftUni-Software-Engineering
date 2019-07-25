namespace MortalEngines
{
    using Commands;
    using Core;
    using Factories;
    using IO;

    public class StartUp
    {
        public static void Main()
        {
            var pilotFactory = new PilotFactory();
            var tankFactory = new TankFactory();
            var fighterFactory = new FighterFactory();

            var machinesManager = new MachinesManager(
                pilotFactory, 
                tankFactory, 
                fighterFactory);

            var commandParser = new CommandParser();
            var dataReader = new ConsoleDataReader();
            var dataWriter = new ConsoleDataWriter();

            var engine = new Engine(
                machinesManager, 
                commandParser, 
                dataReader, 
                dataWriter);

            engine.Run();
        }
    }
}