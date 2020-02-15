namespace Andreys.Models
{
    using Enums;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public CategoryType Category { get; set; }

        public GenderType Gender { get; set; }
    }
}