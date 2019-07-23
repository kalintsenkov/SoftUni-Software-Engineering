namespace AnimalCentre.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;
    using Exceptions;
    using Factories.Contracts;

    public class AnimalCentre : IAnimalCentre
    {
        private readonly IHotel hotel;
        private readonly IAnimalFactory animalFactory;
        private readonly IProcedureFactory procedureFactory;

        private readonly List<IAnimal> animals;
        private readonly List<IProcedure> procedures;
        private readonly Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre(
            IHotel hotel,
            IAnimalFactory animalFactory,
            IProcedureFactory procedureFactory)
        {
            this.hotel = hotel;
            this.animalFactory = animalFactory;
            this.procedureFactory = procedureFactory;

            this.animals = new List<IAnimal>();
            this.procedures = new List<IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);
            this.animals.Add(animal);

            return string.Format(OutputMessages.AnimalAddedSuccessfully, animal.Name);
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(Chip));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadChipProcedure, animal.Name);
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(Vaccinate));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadVaccinationProcedure, animal.Name);
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(Fitness));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadFitnessProcedure, animal.Name);
        }

        public string Play(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(Play));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadPlayProcedure, animal.Name, procedureTime);
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(DentalCare));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadDentalCareProcedure, animal.Name);
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = this.animals.FirstOrDefault(x => x.Name == name);

            this.CheckAnimal(animal);

            var procedure = this.procedureFactory.CreateProcedure(nameof(NailTrim));

            this.procedures.Add(procedure);

            procedure.DoService(animal, procedureTime);

            return string.Format(OutputMessages.AnimalHadNailTrimProcedure, animal.Name);
        }

        public string Adopt(string animalName, string owner)
        {
            this.hotel.Adopt(animalName, owner);

            var animal = this.animals.FirstOrDefault(x => x.Name == animalName);

            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<string>());
            }

            this.adoptedAnimals[owner].Add(animal.Name);

            if (animal.IsChipped)
            {
                return string.Format(OutputMessages.OwnerAdoptedChippedAnimal, owner);
            }
            else
            {
                return string.Format(OutputMessages.OwnerAdoptedAnimalWithoutChip, owner);
            }
        }

        public string GetAdoptedAnimals()
        {
            var result = new StringBuilder();

            foreach (var (owner, animals) in this.adoptedAnimals.OrderBy(x => x.Key))
            {
                result.AppendLine($"--Owner: {owner}");
                result.AppendLine($"    - Adopted animals: {string.Join(" ", animals)}");
            }

            return result.ToString().TrimEnd();
        }

        public string History(string type)
        {
            var result = new StringBuilder();

            result.AppendLine($"{type}");

            foreach (var procedure in this.procedures.Where(x => x.GetType().Name == type))
            {
                result.AppendLine($"{procedure.History()}");
            }

            return result.ToString().TrimEnd();
        }

        private void CheckAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentException(ExceptionMessages.AnimalDoesNotExists, animal.Name);
            }
        }
    }
}
