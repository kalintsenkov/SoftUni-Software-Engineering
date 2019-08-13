namespace ViceCity
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.Neghbourhoods;
    using Models.Neghbourhoods.Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IPlayer mainPlayer = new MainPlayer();
            INeighbourhood gangNeighbourhood = new GangNeighbourhood();
            IGunFactory gunFactory = new GunFactory();

            IController controller = new Controller(
                mainPlayer, 
                gangNeighbourhood, 
                gunFactory);

            IEngine engine = new Engine(
                reader,
                writer,
                controller);

            engine.Run();
        }
    }
}
