namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Contracts;
    using Exceptions;

    public class Tiger : Feline
    {
        private const double GainValue = 1.00;

        public Tiger(
            string name, 
            double weight, 
            string livingRegion, 
            string breed) 
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
