namespace Logger.Factories
{
    using Contracts;
    using Models.Contracts;
    using Models.Files;

    public class LogFileFactory : ILogFileFactory
    {
        public IFile GetLogFile()
            => new LogFile();
    }
}
