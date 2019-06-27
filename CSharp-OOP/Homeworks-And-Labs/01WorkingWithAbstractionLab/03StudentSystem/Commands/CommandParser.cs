namespace StudentSystemCatalog.Commands
{
    using System.Linq;

    public class CommandParser
    {
        public Command Parse(string command)
        {
            var parts = command.Split();

            return new Command
            {
                Name = parts[0],
                Arguments = parts.Skip(1).ToArray()
            };
        }
    }
}
