namespace Logger.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using Logger.Factories.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IErrorFactory errorFactory;

        public Engine(
            ILogger logger,
            IErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                var errorArguments = command
                    .Split("|")
                    .ToArray();

                var level = errorArguments[0];
                var date = errorArguments[1];
                var message = errorArguments[2];

                try
                {
                    var error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger);
        }
    }
}
