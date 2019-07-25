namespace MortalEngines.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Entities.Machines;

    public class PilotFactory : IPilotFactory
    {
        public IPilot CreatePilot(string name)
            => new Pilot(name);
    }
}
