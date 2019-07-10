namespace FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Average(x => x.OverallSkill), 0);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var playerToRemove = this.players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
