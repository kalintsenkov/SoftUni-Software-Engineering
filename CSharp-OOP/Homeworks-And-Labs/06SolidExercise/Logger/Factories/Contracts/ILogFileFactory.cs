namespace Logger.Factories.Contracts
{
    using Models.Contracts;

    public interface ILogFileFactory
    {
        IFile GetLogFile();
    }
}
