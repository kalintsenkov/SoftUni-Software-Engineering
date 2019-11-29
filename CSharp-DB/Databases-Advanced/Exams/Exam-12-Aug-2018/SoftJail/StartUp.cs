namespace SoftJail
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
            using var context = new SoftJailDbContext();

            BonusTask(context);
        }

        private static void BonusTask(SoftJailDbContext context)
        {
            var bonusOutput = Bonus.ReleasePrisoner(context, 13);
            Console.WriteLine(bonusOutput);
        }

        private static void ResetDatabase(SoftJailDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var inputDepartmentsJson = File.ReadAllText(@".\..\..\..\Datasets\ImportDepartmentsCells.json");
            var departmentsResult = Deserializer.ImportDepartmentsCells(context, inputDepartmentsJson);

            var inputPrisonersJson = File.ReadAllText(@".\..\..\..\Datasets\ImportPrisonersMails.json");
            var prisonersResult = Deserializer.ImportPrisonersMails(context, inputPrisonersJson);

            var inputPrisonersXml = File.ReadAllText(@".\..\..\..\Datasets\ImportOfficersPrisoners.xml");
            var officersResult = Deserializer.ImportOfficersPrisoners(context, inputPrisonersXml);
        }
    }
}