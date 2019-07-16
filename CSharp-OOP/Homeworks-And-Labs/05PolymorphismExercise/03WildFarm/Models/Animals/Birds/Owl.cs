namespace WildFarm.Models.Animals.Birds
{
    using Contracts;
    using Exceptions;

    public class Owl : Bird
    {
        private const double GainValue = 0.25;

        public Owl(
            string name, 
            double weight,
            double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            var animalType = this.GetType().Name;
            var foodType = food.GetType().Name;

            if (foodType == "Fruit" || foodType == "Seeds" || foodType == "Vegetable")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += this.FoodEaten * GainValue;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
