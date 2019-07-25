namespace MortalEngines.Entities.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                this.pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var attackDamage = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= attackDamage;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints:F2}");
            result.AppendLine($" *Attack: {this.AttackPoints:F2}");
            result.AppendLine($" *Defense: {this.DefensePoints:F2}");
            result.Append(" *Targets: ");

            if (this.Targets.Count == 0)
            {
                result.AppendLine("None");
            }
            else
            {
                result.AppendLine($"{string.Join(",", this.Targets)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
