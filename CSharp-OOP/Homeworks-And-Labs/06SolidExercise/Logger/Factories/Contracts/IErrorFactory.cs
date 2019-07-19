namespace Logger.Factories.Contracts
{
    using Models.Contracts;

    public interface IErrorFactory
    {
        IError GetError(string dateString, string levelString, string message);
    }
}
