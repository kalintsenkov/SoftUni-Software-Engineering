namespace StorageMaster.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Models.Storages;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            var storageType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => !x.IsAbstract && x.Name == type)
                .FirstOrDefault();

            if (storageType == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            var storage = (Storage)Activator.CreateInstance(storageType, name);

            return storage;
        }
    }
}
