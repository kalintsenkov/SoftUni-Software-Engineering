namespace SpaceStation.Factories
{
    using System;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Utilities.Messages;

    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if(type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautType);
            }

            return astronaut;
        }
    }
}
