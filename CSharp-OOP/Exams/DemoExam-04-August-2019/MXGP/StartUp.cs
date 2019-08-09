namespace MXGP
{
    using Core;
    using Core.Factories;
    using IO;
    using Repositories;

    public class StartUp
    {
        public static void Main()
        {
            var raceRepo = new RaceRepository();
            var riderRepo = new RiderRepository();
            var motorcycleRepo = new MotorcycleRepository();

            var raceFactory = new RaceFactory();
            var riderFactory = new RiderFactory();
            var motorcycleFactory = new MotorcycleFactory();

            var championshipController = new ChampionshipController(
                raceRepo,
                riderRepo, 
                motorcycleRepo,
                raceFactory, 
                riderFactory, 
                motorcycleFactory);

            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();

            var engine = new Engine(
                championshipController,
                consoleReader,
                consoleWriter);

            engine.Run();
        }
    }
}
