namespace StorageMaster.Core
{
    using System;
    using System.Linq;
    using IO.Contracts;

    public class Engine
    {
        private const string EndCommand = "END";

        private readonly StorageMaster storageMaster;

        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Engine(
            StorageMaster storageMaster,
            IReader dataReader,
            IWriter dataWriter)
        {
            this.storageMaster = storageMaster;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            var input = this.dataReader.ReadLine();

            while (input != EndCommand)
            {
                try
                {
                    this.ExecuteCommands(input);
                }
                catch (InvalidOperationException ioe)
                {
                    this.dataWriter.WriteLine($"Error: {ioe.Message}");
                }

                input = this.dataReader.ReadLine();
            }

            var summary = this.storageMaster.GetSummary();

            this.dataWriter.WriteLine(summary);
        }

        private void ExecuteCommands(string input)
        {
            var inputParts = input.Split();

            var commandName = inputParts[0];

            var message = string.Empty;

            if (commandName == "AddProduct")
            {
                var type = inputParts[1];
                var price = double.Parse(inputParts[2]);

                message = this.storageMaster.AddProduct(type, price);
            }
            else if (commandName == "RegisterStorage")
            {
                var type = inputParts[1];
                var name = inputParts[2];

                message = this.storageMaster.RegisterStorage(type, name);
            }
            else if (commandName == "SelectVehicle")
            {
                var storageName = inputParts[1];
                var garageSlot = int.Parse(inputParts[2]);

                message = this.storageMaster.SelectVehicle(storageName, garageSlot);
            }
            else if (commandName == "LoadVehicle")
            {
                var productNames = inputParts.Skip(1);

                message = this.storageMaster.LoadVehicle(productNames);

            }
            else if (commandName == "SendVehicleTo")
            {
                var sourceName = inputParts[1];
                var sourceGarageSlot = int.Parse(inputParts[2]);
                var destinationName = inputParts[3];

                message = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
            }
            else if (commandName == "UnloadVehicle")
            {
                var storageName = inputParts[1];
                var garageSlot = int.Parse(inputParts[2]);

                message = this.storageMaster.UnloadVehicle(storageName, garageSlot);
            }
            else if (commandName == "GetStorageStatus")
            {
                var storageName = inputParts[1];

                message = this.storageMaster.GetStorageStatus(storageName);
            }

            this.dataWriter.WriteLine(message);
        }
    }
}
