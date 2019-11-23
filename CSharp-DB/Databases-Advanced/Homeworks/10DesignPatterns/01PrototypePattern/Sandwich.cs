namespace PrototypePattern
{
    using System;

    public class Sandwich : SandwichPrototype
    {
        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.Bread = bread;
            this.Meat = meat;
            this.Cheese = cheese;
            this.Veggies = veggies;
        }

        public string Bread { get; private set; }

        public string Meat { get; private set; }

        public string Cheese { get; private set; }

        public string Veggies { get; private set; }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngredientList();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientList}");

            return (SandwichPrototype)this.MemberwiseClone();
        }

        private string GetIngredientList()
        {
            return $"{this.Bread}, {this.Meat}, {this.Cheese}, {this.Veggies}";
        }
    }
}
