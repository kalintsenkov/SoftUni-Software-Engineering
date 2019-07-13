namespace MilitaryElite.Contracts
{
    using Enumerations;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
