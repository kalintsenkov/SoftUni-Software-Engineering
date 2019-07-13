namespace BirthdayCelebrations.Commands
{
    using System.Linq;

    public class CommandParser
    {
        public Command Parse(string input)
        {
            var parts = input.Split();
            var name = parts[0];
            var arguments = parts.Skip(1).ToArray();

            return new Command(name, arguments);
        }
    }
}
