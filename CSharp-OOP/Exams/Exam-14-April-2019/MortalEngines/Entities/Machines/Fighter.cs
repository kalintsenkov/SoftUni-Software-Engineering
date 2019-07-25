namespace MortalEngines.Entities.Machines
{
    using System.Text;

    using Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private const double AttackPointsValue = 50;
        private const double DefensivePointsValue = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(
                  name,
                  attackPoints + AttackPointsValue,
                  defensePoints - DefensivePointsValue,
                  InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= AttackPointsValue;
                this.DefensePoints += DefensivePointsValue;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += AttackPointsValue;
                this.DefensePoints -= DefensivePointsValue;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($" *Aggressive: {(this.AggressiveMode ? "ON" : "OFF")}");

            return result.ToString().TrimEnd();
        }
    }
}
