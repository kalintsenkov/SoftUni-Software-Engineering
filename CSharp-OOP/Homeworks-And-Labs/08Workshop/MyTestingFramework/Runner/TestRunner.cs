namespace MyTestingFramework.Runner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using MyTestingFramework.Attributes;

    public class TestRunner
    {
        public List<string> Run(string path)
        {
            var resultsList = new List<string>();

            var testClasses = Assembly
                .LoadFile(path)
                .GetTypes()
                .Where(x => x.GetCustomAttributes<TestClassAttribute>().Any())
                .ToList();

            foreach (var classType in testClasses)
            {
                var classMethods = classType
                    .GetMethods()
                    .Where(x => x.GetCustomAttributes<TestMethodAttribute>().Any())
                    .ToList();

                var classInstance = Activator.CreateInstance(classType);

                foreach (var method in classMethods)
                {
                    try
                    {
                        method.Invoke(classInstance, new object[0]);

                        resultsList.Add($"{method.Name} passed successfully!");
                    }
                    catch (TargetInvocationException ex)
                    {
                        resultsList.Add($"{method.Name} failed! {ex.InnerException.Message}");
                    }
                }
            }

            return resultsList;
        }
    }
}
