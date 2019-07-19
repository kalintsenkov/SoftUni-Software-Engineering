namespace Logger.Factories.Contracts
{
    using Models.Contracts;

    public interface ILayoutFactory
    {
        ILayout GetLayout(string type);
    }
}
