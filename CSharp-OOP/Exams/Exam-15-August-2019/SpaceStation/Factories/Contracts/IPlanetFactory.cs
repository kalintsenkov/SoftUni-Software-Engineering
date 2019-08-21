namespace SpaceStation.Factories.Contracts
{
    using Models.Planets;

    public interface IPlanetFactory
    {
        IPlanet CreatePlanet(string planetName, params string[] items);
    }
}
