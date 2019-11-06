namespace P03_FootballBetting
{
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
