namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;

    using Bags;
    using Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private const int OxygenDecreasement = 10;

        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath
            => this.Oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (this.Oxygen - OxygenDecreasement > 0)
            {
                this.Oxygen -= OxygenDecreasement;
            }
            else
            {
                this.Oxygen = 0;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Name: {this.Name}");
            result.AppendLine($"Oxygen: {this.Oxygen}");

            if (this.Bag.Items.Count == 0)
            {
                result.AppendLine("Bag items: none");
            }
            else
            {
                result.AppendLine($"Bag items: {string.Join(", ", this.Bag.Items)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
