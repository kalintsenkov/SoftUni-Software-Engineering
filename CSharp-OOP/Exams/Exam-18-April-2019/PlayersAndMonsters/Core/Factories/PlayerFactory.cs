namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Players;
    using Models.Players.Contracts;
    using Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == "Advanced")
            {
                player = new Advanced(new CardRepository(), username);
            }
            else if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }

            return player;
        }
    }
}
