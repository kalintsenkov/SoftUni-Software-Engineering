namespace MXGP.Core.Factories
{
    using Contracts;
    using Models.Races;
    using Models.Races.Contracts;

    public class RaceFactory : IRaceFactory
    {
        public IRace CreateRace(string name, int laps) 
            => new Race(name, laps);
    }
}
