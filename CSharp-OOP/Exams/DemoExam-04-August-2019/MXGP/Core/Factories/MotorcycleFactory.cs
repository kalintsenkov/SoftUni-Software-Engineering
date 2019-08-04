namespace MXGP.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Motorcycles.Contracts;

    public class MotorcycleFactory : IMotorcycleFactory
    {
        public IMotorcycle CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycleType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            if (motorcycleType == null)
            {
                throw new ArgumentException("Invalid Motorcycle Type!");
            }

            var parameters = new object[]
            {
                model,
                horsePower
            };

            IMotorcycle motorcycle = null;

            try
            {
                motorcycle = (IMotorcycle)Activator.CreateInstance(motorcycleType, parameters);
            }
            catch (TargetInvocationException ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

            return motorcycle;
        }
    }
}
