namespace Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Factories;
    using Factories.Contracts;
    using Logger.Core;
    using Models;
    using Models.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var appendersCount = int.Parse(Console.ReadLine());

            var appenders = new List<IAppender>();
            var layoutFactory = new LayoutFactory();
            var logFileFactory = new LogFileFactory();
            var appenderFactory = new AppenderFactory(layoutFactory, logFileFactory);

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            var logger = new Logger(appenders);

            var errorFactory = new ErrorFactory();

            var engine = new Engine(logger, errorFactory);

            engine.Run();
        }

        private static void ReadAppendersData(
            int appendersCount, 
            ICollection<IAppender> appenders, 
            IAppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                var appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                var appenderType = appendersInfo[0];
                var layoutType = appendersInfo[1];
                var level = "INFO";

                if (appendersInfo.Length == 3)
                {
                    level = appendersInfo[2];
                }

                try
                {
                    var appender = appenderFactory.GetAppender(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
