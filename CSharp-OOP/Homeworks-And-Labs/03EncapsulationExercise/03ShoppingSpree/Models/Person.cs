namespace ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Exceptions;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
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

        public decimal Money
        {
            get => this.money;

            private set
            {
                this.ValidateMoney(value);

                this.money = value;
            }
        }

        public string AddProductsToBag(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.CannotAffordProductException, 
                        this.Name, 
                        product.Name));
            }

            this.Money -= product.Cost;
            this.products.Add(product);

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (this.products.Count == 0)
            {
                result.AppendLine($"{this.Name} - Nothing bought");
            }
            else
            {
                result.AppendLine($"{this.Name} - {string.Join(", ", this.GetProductsNames())}");
            }

            return result.ToString().TrimEnd();
        }

        private List<string> GetProductsNames()
        {
            var productsNames = new List<string>();

            foreach (var product in this.products)
            {
                productsNames.Add(product.Name);
            }

            return productsNames;
        }

        private void ValidateMoney(decimal targetMoney)
        {
            if (targetMoney < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
            }
        }

        private void ValidateName(string targetName)
        {
            if (string.IsNullOrEmpty(targetName) || string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
            }
        }
    }
}
