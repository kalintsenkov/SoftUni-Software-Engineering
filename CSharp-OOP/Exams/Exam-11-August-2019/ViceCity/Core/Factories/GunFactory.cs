namespace ViceCity.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Guns.Contracts;
    using Utilities.Messages;

    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            var gunType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == type && !x.IsAbstract)
                .FirstOrDefault();

            if (gunType == null)
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidGunType);
            }

            var gun = (IGun)Activator.CreateInstance(gunType, name);

            return gun;
        }
    }
}
