namespace WildFarm.Models.Animals.Birds
{
    using Contracts;

    public class Hen : Bird
    {
        private const double GainValue = 0.35;

        public Hen(
            string name, 
            double weight,
            double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += this.FoodEaten * GainValue;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
