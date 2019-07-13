namespace FoodShortage.Models
{
    using Contracts;

    public class Citizen : Person, IIdentifiable
    {
        public Citizen(
            string name, 
            int age, 
            string id, 
            string birthdate)
            : base(name, age, birthdate)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
