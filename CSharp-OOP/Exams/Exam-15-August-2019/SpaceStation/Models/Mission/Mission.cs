namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;

    using Astronauts.Contracts;
    using Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                var astronaut = astronauts
                    .FirstOrDefault(x => x.CanBreath);

                if (astronaut == null)
                {
                    break;
                }

                var item = planet
                    .Items
                    .FirstOrDefault();

                if (item == null)
                {
                    break;
                }

                astronaut.Breath();

                astronaut
                    .Bag
                    .Items
                    .Add(item);

                planet
                    .Items
                    .Remove(item);
            }
        }
    }
}
