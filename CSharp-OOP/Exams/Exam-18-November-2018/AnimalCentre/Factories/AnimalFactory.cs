namespace AnimalCentre.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name == type)
                .FirstOrDefault();

            var parameters = new object[]
            {
                name,
                energy,
                happiness,
                procedureTime
            };

            IAnimal animal = null;

            try
            {
                animal = (IAnimal)Activator.CreateInstance(animalType, parameters);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.InnerException.Message);
            }

            return animal;
        }
    }
}
