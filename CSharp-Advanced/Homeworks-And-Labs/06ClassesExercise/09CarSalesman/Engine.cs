namespace DefiningClasses
{
    using System;
    using System.Text;

    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) 
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"  {this.Model}:");
            result.AppendLine($"    Power: {this.Power}");

            if (this.Displacement == 0)
            {
                result.AppendLine($"    Displacement: n/a");
            }
            else
            {
                result.AppendLine($"    Displacement: {this.Displacement}");
            }

            if (this.Efficiency == null)
            {
                result.Append($"    Efficiency: n/a");
            }
            else
            {
                result.Append($"    Efficiency: {this.Efficiency}");
            }

            return result.ToString();
        }
    }
}
