namespace MySpecialApp
{
    using System;

    using MyTestingFramework.Runner;

    public class StartUp
    {
        public static void Main()
        {
            var testRunner = new TestRunner();

            var path = @"C:\Users\Amd\source\repos\Workshop\MySpecialApp.Tests\bin\Debug\netcoreapp2.2\MySpecialApp.Tests.dll";

            var testResults = testRunner.Run(path);

            foreach (var result in testResults)
            {
                Console.WriteLine(result);
            }
        }
    }
}
