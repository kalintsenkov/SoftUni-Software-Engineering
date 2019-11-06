namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
