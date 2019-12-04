namespace Cinema.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public Hall Hall { get; set; }
    }
}
