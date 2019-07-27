namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count 
            => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players 
            => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            this.CheckIfPlayerIsNull(player);

            if (this.players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username) 
            => this.players.FirstOrDefault(x => x.Username == username);

        public bool Remove(IPlayer player)
        {
            this.CheckIfPlayerIsNull(player);

            return this.players.Remove(player);
        }

        private void CheckIfPlayerIsNull(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
        }
    }
}
