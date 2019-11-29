namespace SoftJail.DataProcessor
{
    using System;

    using Data;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.Find(prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.ReleaseDate = DateTime.UtcNow;
            prisoner.CellId = null;

            return $"Prisoner {prisoner.FullName} released";
        }
    }
}
