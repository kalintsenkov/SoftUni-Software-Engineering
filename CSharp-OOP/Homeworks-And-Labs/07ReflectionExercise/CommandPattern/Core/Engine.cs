namespace CommandPattern.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                var result = this.commandInterpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}