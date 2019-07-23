namespace AnimalCentre.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        string[] Arguments { get; }
    }
}
