namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
