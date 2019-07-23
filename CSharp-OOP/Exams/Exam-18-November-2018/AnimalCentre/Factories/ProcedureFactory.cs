namespace AnimalCentre.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Contracts;

    public class ProcedureFactory : IProcedureFactory
    {
        public IProcedure CreateProcedure(string type)
        {
           var procedureType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name == type)
                .FirstOrDefault();

            var procedureInstance = (IProcedure)Activator.CreateInstance(procedureType);

            return procedureInstance;
        }
    }
}
