namespace StorageMaster
{
    using Core;
    using Factories;
    using IO;

    public class StartUp
    {
        public static void Main()
        {
            var productFactory = new ProductFactory();
            var storageFactory = new StorageFactory();

            var storageMaster = new StorageMaster(productFactory, storageFactory);
            var consoleDataReader = new ConsoleDataReader();
            var consoleDataWriter = new ConsoleDataWriter();

            var engine = new Engine(storageMaster, consoleDataReader, consoleDataWriter);

            engine.Run();
        }
    }
}
