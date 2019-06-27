namespace _04HotelReservation
{
    using Informations;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var informationParser = new InformationParser();

            var information = informationParser.Parse(input);

            var pricePerDay = information.PricePerDay;
            var days = information.Days;
            var season = information.Season;
            var discountType = information.DiscountType;

            var totalPrice = PriceCalculator.Calculate(pricePerDay, days, season, discountType);

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
