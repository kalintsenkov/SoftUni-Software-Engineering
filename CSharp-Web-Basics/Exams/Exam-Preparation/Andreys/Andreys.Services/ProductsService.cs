namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data;
    using Models;
    using Models.Enums;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext data;

        public ProductsService(AndreysDbContext data)
        {
            this.data = data;
        }

        public void Add(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = this.ParseEnum<CategoryType>(category),
                Gender = this.ParseEnum<GenderType>(gender),
                Price = price
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public TModel GetDetails<TModel>(int id, Expression<Func<Product, TModel>> selectFunc)
            => this.data.Products
                .Where(p => p.Id == id)
                .Select(selectFunc)
                .FirstOrDefault();

        public IEnumerable<TModel> GetAll<TModel>(Expression<Func<Product, TModel>> selectFunc) 
            => this.data.Products.Select(selectFunc).ToList();

        public bool Delete(int id)
        {
            var product = this.data.Products.FirstOrDefault(p => p.Id == id);
            
            if (product == null)
            {
                return false;
            }

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return true;
        }

        private T ParseEnum<T>(string value)
            => (T)Enum.Parse(typeof(T), value);
    }
}