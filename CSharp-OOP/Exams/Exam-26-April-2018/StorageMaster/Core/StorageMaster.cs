namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Factories;
    using Models.Products;
    using Models.Storages;
    using Models.Vehicles;

    public class StorageMaster
    {
        private readonly List<Product> productPool;
        private readonly List<Storage> storageRegistry;

        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;

        private Vehicle vehicle;

        public StorageMaster(
            ProductFactory productFactory,
            StorageFactory storageFactory)
        {
            this.productFactory = productFactory;
            this.storageFactory = storageFactory;

            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            this.vehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (this.vehicle.IsFull)
                {
                    break;
                }

                var product = this.productPool
                    .LastOrDefault(x => x.GetType().Name == productName);

                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                this.vehicle.LoadProduct(product);
                loadedProductsCount++;

                this.productPool.Remove(product);
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.vehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            
            var destinationStorage = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.Name} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);

            var totalProducts = vehicle.Trunk.Count;

            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{totalProducts} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var filtredStorages = this.storageRegistry
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToList();

            var result = new StringBuilder();

            foreach (var storage in filtredStorages)
            {
                result.AppendLine($"{storage.Name}:");
                result.AppendLine($"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
