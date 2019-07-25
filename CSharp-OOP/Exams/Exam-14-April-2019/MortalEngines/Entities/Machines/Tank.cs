namespace MortalEngines.Entities.Machines
{
    using System.Text;

    using Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double AttackPointsValue = 40;
        private const double DefensivePointsValue = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(
                  name,
                  attackPoints - AttackPointsValue,
                  defensePoints + DefensivePointsValue,
                  InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;

                this.AttackPoints += AttackPointsValue;
                this.DefensePoints -= DefensivePointsValue;
            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= AttackPointsValue;
                this.DefensePoints += DefensivePointsValue;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($" *Defense: {(this.DefenseMode ? "ON" : "OFF")}");

            return result.ToString().TrimEnd();
        }
    }
}
