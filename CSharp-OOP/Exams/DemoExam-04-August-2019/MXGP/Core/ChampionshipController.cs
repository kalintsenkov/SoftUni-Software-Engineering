namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Core.Factories.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int RequiredRidersCount = 3;

        private readonly RaceRepository raceRepository;
        private readonly RiderRepository riderRepository;
        private readonly MotorcycleRepository motorcycleRepository;

        private readonly IRaceFactory raceFactory;
        private readonly IRiderFactory riderFactory;
        private readonly IMotorcycleFactory motorcycleFactory;

        public ChampionshipController(
            RaceRepository raceRepository,
            RiderRepository riderRepository,
            MotorcycleRepository motorcycleRepository,
            IRaceFactory raceFactory,
            IRiderFactory riderFactory,
            IMotorcycleFactory motorcycleFactory)
        {
            this.raceRepository = raceRepository;
            this.riderRepository = riderRepository;
            this.motorcycleRepository = motorcycleRepository;

            this.raceFactory = raceFactory;
            this.riderFactory = riderFactory;
            this.motorcycleFactory = motorcycleFactory;
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RiderNotFound,
                        riderName));
            }

            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.MotorcycleNotFound,
                        motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            var rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RiderNotFound,
                        riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.MotorcycleExists,
                        model));
            }

            var motorcycle = this.motorcycleFactory.CreateMotorcycle(type, model, horsePower);
            this.motorcycleRepository.Add(motorcycle);

            return string.Format(
                OutputMessages.MotorcycleCreated,
                motorcycle.GetType().Name,
                motorcycle.Model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceExists,
                        name));
            }

            var race = this.raceFactory.CreateRace(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetAll().Any(x => x.Name == riderName))
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.RiderExists,
                        riderName));
            }

            var rider = this.riderFactory.CreateRider(riderName);
            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository
                .GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            var riders = race
                .Riders
                .OrderByDescending(x => x.Motorcycle
                    .CalculateRacePoints(race.Laps))
                .ToList();

            if (riders.Count < RequiredRidersCount)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceInvalid,
                        raceName,
                        RequiredRidersCount));
            }

            riders[0].WinRace();

            var result = new StringBuilder();

            result.AppendLine($"Rider {riders[0].Name} wins {race.Name} race.");
            result.AppendLine($"Rider {riders[1].Name} is second in {race.Name} race.");
            result.AppendLine($"Rider {riders[2].Name} is third in {race.Name} race.");

            this.raceRepository.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}
