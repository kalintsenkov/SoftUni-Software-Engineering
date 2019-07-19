namespace Logger.Factories.Contracts
{
    using Models.Contracts;

    public interface IAppenderFactory
    {
        IAppender GetAppender(string appenderType, string layoutType, string levelString);
    }
}
