namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var argumentParts = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var commandName = argumentParts[0];
            var commandArguments = argumentParts
                .Skip(1)
                .ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == $"{commandName}Command")
                .FirstOrDefault();

            var commandInstance = (ICommand)Activator.CreateInstance(commandType);

            var result = commandInstance.Execute(commandArguments);

            return result;
        }
    }
}