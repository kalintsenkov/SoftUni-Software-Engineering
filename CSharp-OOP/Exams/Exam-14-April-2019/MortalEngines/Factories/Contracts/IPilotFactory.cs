namespace MortalEngines.Factories.Contracts
{
    using Entities.Contracts;

    public interface IPilotFactory
    {
        IPilot CreatePilot(string name);
    }
}
