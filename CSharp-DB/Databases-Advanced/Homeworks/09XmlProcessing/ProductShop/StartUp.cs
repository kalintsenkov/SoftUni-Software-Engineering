namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using Dtos.Export;
    using Dtos.Import;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
        }

        // Problem. 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var userDtos = (ImportUserDto[])serializer.Deserialize(reader);

            var users = userDtos
                .Select(ud => new User
                {
                    FirstName = ud.FirstName,
                    LastName = ud.LastName,
                    Age = ud.Age
                })
                .ToList();

            context.Users.AddRange(users);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            var productDtos = (ImportProductDto[])serializer.Deserialize(reader);

            var products = productDtos
                .Select(pd => new Product
                {
                    Name = pd.Name,
                    Price = pd.Price,
                    SellerId = pd.SellerId,
                    BuyerId = pd.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            var categoryDtos = (ImportCategoryDto[])serializer.Deserialize(reader);

            var categories = categoryDtos
                .Select(cd => new Category { Name = cd.Name })
                .ToList();

            context.Categories.AddRange(categories);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(
                typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));
            var categoryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);

            var cateogryProducts = categoryProductDtos
                .Select(d => new CategoryProduct
                {
                    CategoryId = d.CategoryId,
                    ProductId = d.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(cateogryProducts);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(
                typeof(ProductInRangeDto[]),
                new XmlRootAttribute("Products"));
            serializer.Serialize(writer, products, ns);

            var productsXml = writer.GetStringBuilder();

            return productsXml.ToString().TrimEnd();
        }

        // Problem. 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new UserProductDto
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            serializer.Serialize(writer, users, ns);

            var soldProductsXml = writer.GetStringBuilder();

            return soldProductsXml.ToString().TrimEnd();
        }

        // Problem. 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryDtos = context.Categories
                .Select(c => new CategoryByProductDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts
                        .Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts
                        .Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(
                typeof(CategoryByProductDto[]),
                new XmlRootAttribute("Categories"));
            serializer.Serialize(writer, categoryDtos, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        // Problem. 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new UserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                            .Select(p => new ProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var userAndProducts = new UserAndProductsDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(UserAndProductsDto), new XmlRootAttribute("Users"));
            serializer.Serialize(writer, userAndProducts, ns);

            var userAndProductsXml = writer.GetStringBuilder();

            return userAndProductsXml.ToString().TrimEnd();
        }
    }
}