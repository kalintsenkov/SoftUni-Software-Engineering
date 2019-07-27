namespace PlayersAndMonsters.Commands
{
    using System.Linq;

    using Contracts;

    public class CommandParser : ICommandParser
    {
        public ICommand Parse(string input)
        {
            var inputParts = input.Split();
            var name = inputParts[0];
            var arguments = inputParts.Skip(1).ToArray();

            return new Command(name, arguments);
        }
    }
}
