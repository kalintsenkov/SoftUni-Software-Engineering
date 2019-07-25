namespace MortalEngines.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Entities.Machines;

    public class TankFactory : ITankFactory
    {
        public ITank CreateTank(string name, double attackPoints, double defensePoints)
            => new Tank(name, attackPoints, defensePoints);
    }
}
