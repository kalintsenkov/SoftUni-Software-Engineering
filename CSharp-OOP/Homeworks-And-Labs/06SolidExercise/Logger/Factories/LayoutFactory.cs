namespace Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Exceptions;
    using Models.Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            var typeToCreate = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == type);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);

            return layout;
        }
    }
}
