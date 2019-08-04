namespace MXGP.Core.Factories.Contracts
{
    using Models.Races.Contracts;

    public interface IRaceFactory
    {
        IRace CreateRace(string name, int laps);
    }
}
