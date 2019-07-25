namespace MortalEngines.Factories.Contracts
{
    using Entities.Contracts;

    public interface ITankFactory
    {
        ITank CreateTank(string name, double attackPoints, double defensePoints);
    }
}
