namespace DefiningClasses
{
    using System;
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Model}:");
            result.AppendLine($"{this.Engine}");

            if (this.Weight == 0)
            {
                result.AppendLine($"  Weight: n/a");
            }
            else
            {
                result.AppendLine($"  Weight: {this.Weight}");
            }

            if(this.Color == null)
            {
                result.Append($"  Color: n/a");
            }
            else
            {
                result.Append($"  Color: {this.Color}");
            }

            return result.ToString();
        }
    }
}
