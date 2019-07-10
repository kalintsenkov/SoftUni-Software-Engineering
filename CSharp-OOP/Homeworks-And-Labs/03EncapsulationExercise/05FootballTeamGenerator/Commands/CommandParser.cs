namespace FootballTeamGenerator.Commands
{
    using System.Linq;

    public class CommandParser
    {
        public Command Parse(string input)
        {
            var inputParts = input.Split(";");
            var name = inputParts[0];
            var arguments = inputParts.Skip(1).ToArray();

            return new Command(name, arguments);
        }
    }
}
