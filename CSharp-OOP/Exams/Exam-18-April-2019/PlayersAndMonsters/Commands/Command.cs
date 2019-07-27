namespace PlayersAndMonsters.Commands
{
    using Contracts;

    public class Command : ICommand
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; private set; }

        public string[] Arguments { get; private set; }
    }
}
