namespace _04HotelReservation
{
    using Enums;

    public static class PriceCalculator
    {
        public static decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount)
        {
            decimal totalPrice = pricePerDay * days * (decimal)season;
            decimal discountPrice = totalPrice - (totalPrice * ((decimal)discount / 100));

            return discountPrice;
        }
    }
}
