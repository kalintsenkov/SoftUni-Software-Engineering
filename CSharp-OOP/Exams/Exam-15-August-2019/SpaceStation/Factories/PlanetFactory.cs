namespace SpaceStation.Factories
{
    using Contracts;
    using Models.Planets;

    public class PlanetFactory : IPlanetFactory
    {
        public IPlanet CreatePlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            return planet;
        }
    }
}
