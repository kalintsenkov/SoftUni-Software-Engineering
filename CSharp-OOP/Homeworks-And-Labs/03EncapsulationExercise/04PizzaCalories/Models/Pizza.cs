namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    public class Pizza
    {
        private const int MaxToppingsNumber = 10;
        private const int MinNameLenght = 1;
        private const int MaxNameLenght = 15;

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        public Dough Dough { get; private set; }

        public double TotalCalories =>
            this.Dough.CaloriesPerGram
            + this.toppings.Sum(x => x.CaloriesPerGram);

        public int ToppingsCount => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount > MaxToppingsNumber)
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidNumberOfToppingsException);
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

        private void ValidateName(string targetName)
        {
            if (targetName.Length > MaxNameLenght
                || targetName.Length < MinNameLenght
                || string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException(
                        ExceptionMessages.InvalidPizzaNameException);
            }
        }
    }
}
