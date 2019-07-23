namespace AnimalCentre.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;

        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count == Capacity)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NotEnoughCapacity);
            }

            if (this.animals.Any(x => x.Key == animal.Name))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.AnimalAlreadyExists, animal.Name));
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.Any(x => x.Key == animalName))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.AnimalDoesNotExists, animalName));
            }

            var animal = this.animals
                .Select(x => x.Value)
                .Where(x => x.Name == animalName)
                .FirstOrDefault();

            animal.Owner = owner;
            animal.IsAdopt = true;

            this.animals.Remove(animal.Name);
        }
    }
}
