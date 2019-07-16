namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Contracts;
    using Exceptions;

    public class Cat : Feline
    {
        private const double GainValue = 0.30;

        public Cat(
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

            if (foodType == "Fruit" || foodType == "Seeds")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += this.FoodEaten * GainValue;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
