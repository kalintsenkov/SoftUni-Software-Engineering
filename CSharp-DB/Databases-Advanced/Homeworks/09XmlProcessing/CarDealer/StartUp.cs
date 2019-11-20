namespace CarDealer
{
    using System;
    using System.Collections.Generic;
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

        // Problem. 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));
            var supplierDtos = (ImportSupplierDto[])serializer.Deserialize(reader);

            var suppliers = supplierDtos
                .Select(sd => new Supplier
                {
                    Name = sd.Name,
                    IsImporter = sd.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));
            var partDtos = (ImportPartDto[])serializer.Deserialize(reader);

            var parts = partDtos
                .Where(pd => context.Suppliers.Any(s => s.Id == pd.SupplierId))
                .Select(pd => new Part
                {
                    Name = pd.Name,
                    Price = pd.Price,
                    Quantity = pd.Quantity,
                    SupplierId = pd.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            var importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        // Problem. 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            var carDtos = (ImportCarDto[])serializer.Deserialize(reader);

            foreach (var dto in carDtos)
            {
                var car = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                context.Cars.Add(car);

                var partsId = dto.Parts
                    .Distinct()
                    .Select(p => p.Id)
                    .ToArray();

                foreach (var partId in partsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDtos.Length}";
        }

        // Problem. 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])serializer.Deserialize(reader);

            var customers = customersDto
                .Select(cd => new Customer
                {
                    Name = cd.Name,
                    BirthDate = cd.BirthDate,
                    IsYoungDriver = cd.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // Problem. 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var saleDtos = (ImportSaleDto[])serializer.Deserialize(reader);

            var sales = saleDtos
                .Where(sd => context.Cars.Any(c => c.Id == sd.CarId))
                .Select(sd => new Sale
                {
                    CarId = sd.CarId,
                    CustomerId = sd.CustomerId,
                    Discount = sd.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // Problem. 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(CarDistanceDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(writer, cars, ns);

            var carsXml = writer.GetStringBuilder();

            return carsXml.ToString().TrimEnd();
        }

        // Problem. 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarMakeDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(CarMakeDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(writer, cars, ns);

            var carsXml = writer.GetStringBuilder();

            return carsXml.ToString().TrimEnd();
        }

        // Problem. 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(LocalSuppliersDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(writer, suppliers, ns);

            var suppliersXml = writer.GetStringBuilder();

            return suppliersXml.ToString().TrimEnd();
        }

        // Problem. 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new CarPartsDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(writer, cars, ns);

            var carsXml = writer.GetStringBuilder();

            return carsXml.ToString().TrimEnd();
        }

        // Problem. 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpendMoney = c.Sales
                        .SelectMany(s => s.Car.PartCars)
                        .Sum(p => p.Part.Price)
                })
                .OrderByDescending(c => c.SpendMoney)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(writer, customers, ns);

            var customersXml = writer.GetStringBuilder();

            return customersXml.ToString().TrimEnd();
        }

        // Problem. 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleDiscountDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars
                        .Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price)
                        - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(SaleDiscountDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(writer, sales, ns);

            var salesXml = writer.GetStringBuilder();

            return salesXml.ToString().TrimEnd();
        }
    }
}