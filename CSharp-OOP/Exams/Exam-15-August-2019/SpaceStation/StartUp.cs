namespace SpaceStation
{
    using Core;
    using Factories;
    using IO;
    using Models.Mission;
    using Repositories;

    public class StartUp
    {
        public static void Main()
        {
            var writer = new Writer();
            var reader = new Reader();

            var astronautRepository = new AstronautRepository();
            var planetRepository = new PlanetRepository();
            var astronautFactory = new AstronautFactory();
            var planetFactory = new PlanetFactory();
            var mission = new Mission();

            var controller = new Controller(
                astronautRepository,
                planetRepository,
                astronautFactory,
                planetFactory,
                mission);

            var engine = new Engine(
                writer, 
                reader, 
                controller);

            engine.Run();
        }
    }
}