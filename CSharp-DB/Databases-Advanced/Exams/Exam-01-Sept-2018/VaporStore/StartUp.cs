namespace VaporStore
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using DataProcessor;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new VaporStoreDbContext();

            BonusTask(context);
        }

        private static void BonusTask(VaporStoreDbContext context)
        {
            var bonusOutput = Bonus.UpdateEmail(context, "atobin", "amontobin@gmail.com");
            Console.WriteLine(bonusOutput);
        }
    }
}