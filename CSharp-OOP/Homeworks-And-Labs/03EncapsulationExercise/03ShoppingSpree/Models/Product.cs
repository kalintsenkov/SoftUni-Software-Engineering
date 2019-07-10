namespace ShoppingSpree.Models
{
    using System;

    using Exceptions;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get => this.cost;

            private set
            {
                this.ValidateCost(value);

                this.cost = value;
            }
        }

        private void ValidateName(string targetName)
        {
            if (string.IsNullOrEmpty(targetName) || string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
            }
        }

        private void ValidateCost(decimal targetMoney)
        {
            if (targetMoney < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
            }
        }
    }
}
