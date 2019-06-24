namespace _04.HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {
            this.PricePerDay = pricePerDay;
            this.NumberOfDays = numberOfDays;
            this.Season = season;
            this.DiscountType = discountType;
        }

        public decimal PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public Season Season { get; set; }

        public DiscountType DiscountType { get; set; }

        public decimal CalculatePrice()
        {
            decimal price = this.NumberOfDays * this.PricePerDay * (decimal)this.Season;
            price -= price * ((decimal)this.DiscountType / 100);
            return price;
        }
    }
}