namespace WildFarm.Models.Animals.Mammals
{
    using Contracts;

    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(
            string name, 
            double weight, 
            string livingRegion,
            string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
