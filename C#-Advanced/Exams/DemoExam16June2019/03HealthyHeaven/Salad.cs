namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Salad
    {
        private List<Vegetable> products;

        public string Name { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories() => this.products.Sum(x => x.Calories);

        public int GetProductCount() => this.products.Count;

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var product in this.products)
            {
                result.AppendLine($"{product}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
