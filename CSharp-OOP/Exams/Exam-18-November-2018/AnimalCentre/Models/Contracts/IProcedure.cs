namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IProcedure
    {
        IReadOnlyCollection<IAnimal> ProcedureHistory { get; }

        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}
