namespace MortalEngines.Factories.Contracts
{
    using Entities.Contracts;

    public interface IFighterFactory
    {
        IFighter CreateFighter(string name, double attackPoints, double defensePoints);
    }
}
