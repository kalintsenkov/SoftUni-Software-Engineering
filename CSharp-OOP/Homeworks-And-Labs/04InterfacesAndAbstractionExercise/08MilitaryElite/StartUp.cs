namespace MilitaryElite
{
    using Commands;
    using Core;

    public class StartUp
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var engine = new Engine(commandParser);

            engine.Run();
        }
    }
}
