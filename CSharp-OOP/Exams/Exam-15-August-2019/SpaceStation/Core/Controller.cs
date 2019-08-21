namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Factories.Contracts;
    using Models.Mission;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;

        private readonly IAstronautFactory astronautFactory;
        private readonly IPlanetFactory planetFactory;

        private readonly IMission mission;

        private int exploredPlanetsCount;

        public Controller(
            AstronautRepository astronautRepository,
            PlanetRepository planetRepository,
            IAstronautFactory astronautFactory,
            IPlanetFactory planetFactory,
            IMission mission)
        {
            this.astronautRepository = astronautRepository;
            this.planetRepository = planetRepository;

            this.astronautFactory = astronautFactory;
            this.planetFactory = planetFactory;

            this.mission = mission;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.astronautFactory.CreateAstronaut(type, astronautName);

            this.astronautRepository.Add(astronaut);

            return string.Format(
                OutputMessages.AstronautAdded,
                type,
                astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = this.planetFactory.CreatePlanet(planetName, items);

            this.planetRepository.Add(planet);

            return string.Format(
                OutputMessages.PlanetAdded,
                planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository
                .FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.InvalidRetiredAstronaut,
                        astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(
                OutputMessages.AstronautRetired,
                astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetRepository
                .FindByName(planetName);

            var astronauts = this.astronautRepository
                .Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            var deadAstronauts = astronauts
                .Count(x => !x.CanBreath);

            return string.Format(
                OutputMessages.PlanetExplored,
                planetName,
                deadAstronauts);
        }

        public string Report()
        {
            var report = new StringBuilder();

            report.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            report.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                report.AppendLine($"{astronaut}");
            }

            return report.ToString().TrimEnd();
        }
    }
}
