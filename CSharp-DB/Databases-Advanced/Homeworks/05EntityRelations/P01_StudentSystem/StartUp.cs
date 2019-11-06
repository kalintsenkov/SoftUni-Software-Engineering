namespace P01_StudentSystem
{
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
