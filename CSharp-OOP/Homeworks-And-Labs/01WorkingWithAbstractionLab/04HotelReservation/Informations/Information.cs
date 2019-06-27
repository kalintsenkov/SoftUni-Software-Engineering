namespace _04HotelReservation.Informations
{
    using Enums;

    public class Information
    {
        public Information(decimal pricePerDay, int days, Season season, Discount discountType)
        {
            this.PricePerDay = pricePerDay;
            this.Days = days;
            this.Season = season;
            this.DiscountType = discountType;
        }

        public decimal PricePerDay { get; private set; }

        public int Days { get; private set; }

        public Season Season { get; private set; }

        public Discount DiscountType { get; private set; }
    }
}
