namespace AnimalCentre.Factories.Contracts
{
    using Models.Contracts;

    public interface IProcedureFactory
    {
        IProcedure CreateProcedure(string type);
    }
}
