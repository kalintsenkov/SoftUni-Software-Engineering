namespace _04HotelReservation.Informations
{
    using Enums;
    using System;

    public class InformationParser
    {
        public Information Parse(string input)
        {
            var parts = input.Split();

            var pricePerDay = decimal.Parse(parts[0]);
            var numberOfDays = int.Parse(parts[1]);
            var season = Enum.Parse<Season>(parts[2]);
            var discountType = Discount.None;

            if (parts.Length == 4)
            {
                discountType = Enum.Parse<Discount>(parts[3]);
            }

            return new Information(pricePerDay, numberOfDays, season, discountType);
        }
    }
}
