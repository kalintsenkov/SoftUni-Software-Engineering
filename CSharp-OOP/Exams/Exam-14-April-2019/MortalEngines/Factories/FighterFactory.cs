namespace MortalEngines.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Entities.Machines;

    public class FighterFactory : IFighterFactory
    {
        public IFighter CreateFighter(string name, double attackPoints, double defensePoints)
            => new Fighter(name, attackPoints, defensePoints);
    }
}
