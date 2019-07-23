namespace AnimalCentre.Factories.Contracts
{
    using Models.Contracts;

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime);
    }
}
