namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> salads;

        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.salads.Add(salad);
        }

        public bool Buy(string name)
        {
            if (salads.Any(x => x.Name == name))
            {
                salads.RemoveAll(x => x.Name == name);
                return true;
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return this.salads.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} have {this.salads.Count} salads:");

            foreach (var salad in this.salads)
            {
                result.AppendLine($"{salad}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
