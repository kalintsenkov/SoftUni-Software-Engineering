namespace CommandPattern
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);

            engine.Run();
        }
    }
}
