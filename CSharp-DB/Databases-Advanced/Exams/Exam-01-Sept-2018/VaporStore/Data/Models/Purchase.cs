namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Enums;

    public class Purchase
    {
        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
