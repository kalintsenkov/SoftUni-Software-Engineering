namespace HealthyHeaven
{
    public class Vegetable
    {
        public string Name { get; private set; }

        public int Calories { get; private set; }

        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public override string ToString()
        {
            return $" - {this.Name} have {this.Calories} calories";
        }
    }
}
