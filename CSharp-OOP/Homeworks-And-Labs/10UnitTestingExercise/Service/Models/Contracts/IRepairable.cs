namespace Service.Models.Contracts
{
    using System.Collections.Generic;

    public interface IRepairable
    {
        string Make { get; }

        IReadOnlyCollection<IPart> Parts { get; }

        void AddPart(IPart part);

        void RemovePart(string partName);

        void RepairPart(string partName);
    }
}
