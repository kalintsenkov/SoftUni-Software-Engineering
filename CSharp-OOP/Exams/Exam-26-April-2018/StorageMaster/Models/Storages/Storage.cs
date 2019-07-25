namespace StorageMaster.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Products;
    using Vehicles;

    public abstract class Storage
    {
        private readonly List<Product> products;
        private readonly Vehicle[] garage;

        protected Storage(
            string name, 
            int capacity, 
            int garageSlots, 
            IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.products = new List<Product>();
            this.garage = new Vehicle[this.GarageSlots];

            this.InitializeVehicles(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull
            => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage 
            => this.garage;

        public IReadOnlyCollection<Product> Products
            => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            this.CheckGarageSlot(garageSlot);

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation) 
        {
            var vehicle = this.GetVehicle(garageSlot);

            var hasFreeGarageSlots = deliveryLocation.Garage.Any(x => x == null);

            if (hasFreeGarageSlots == false)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            var addedSlot = deliveryLocation.AddVehicle(vehicle);

            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = this.GetVehicle(garageSlot);

            var unloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull) 
            {
                var vehicleProduct = vehicle.Unload();

                this.products.Add(vehicleProduct);
                unloadedProducts++;
            }

            return unloadedProducts;
        }

        private void CheckGarageSlot(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
        }

        private int AddVehicle(Vehicle vehicle)
        {
            var emptySlot = Array.IndexOf(this.garage, null);

            this.garage[emptySlot] = vehicle;

            return emptySlot;
        }

        private void InitializeVehicles(IEnumerable<Vehicle> vehicles)
        {
            var index = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }
    }
}
