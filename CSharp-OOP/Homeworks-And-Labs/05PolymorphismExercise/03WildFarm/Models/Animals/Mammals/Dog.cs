namespace WildFarm.Models.Animals.Mammals
{
    using Contracts;
    using Exceptions;

    public class Dog : Mammal
    {
        private const double GainValue = 0.40;

        public Dog(
            string name, 
            double weight,
            string livingRegion) 
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
