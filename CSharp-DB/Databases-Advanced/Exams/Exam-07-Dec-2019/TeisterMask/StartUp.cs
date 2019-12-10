namespace TeisterMask
{
    using System;
    using System.IO;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using DataProcessor;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new TeisterMaskContext();

            ResetDatabase(context);
        }

        private static void ResetDatabase(TeisterMaskContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var projectsXml = File.ReadAllText(@".\..\..\..\Datasets\projects.xml");
            var projectsResult = Deserializer.ImportProjects(context, projectsXml);

            Console.WriteLine(projectsResult);

            var employeesJson = File.ReadAllText(@".\..\..\..\Datasets\employees.json");
            var employeesResult = Deserializer.ImportEmployees(context, employeesJson);

            Console.WriteLine(employeesResult);
        }
    }
}