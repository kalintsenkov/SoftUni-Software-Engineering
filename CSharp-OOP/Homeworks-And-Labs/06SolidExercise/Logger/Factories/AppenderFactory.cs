namespace Logger.Factories
{
    using System;

    using Contracts;
    using Exceptions;
    using Models.Appenders;
    using Models.Contracts;
    using Models.Enumerations;

    public class AppenderFactory : IAppenderFactory
    {
        private readonly ILayoutFactory layoutFactory;
        private readonly ILogFileFactory logFileFactory;

        public AppenderFactory(
            ILayoutFactory layoutFactory,
            ILogFileFactory logFileFactory)
        {
            this.layoutFactory = layoutFactory;
            this.logFileFactory = logFileFactory;
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {
            var isParsed = Enum.TryParse(levelString, out Level level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            var layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                var file = this.logFileFactory.GetLogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
