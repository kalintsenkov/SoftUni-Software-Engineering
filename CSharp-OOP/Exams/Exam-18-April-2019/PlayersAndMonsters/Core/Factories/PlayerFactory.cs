namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Players.Contracts;
    using Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == type && !x.IsAbstract)
                .FirstOrDefault();

            if (playerType == null)
            {
                throw new ArgumentException("Invalid player type!");
            }

            var parameters = new object[]
            {
                new CardRepository(),
                username
            };

            var player = (IPlayer)Activator.CreateInstance(playerType, parameters);

            return player;
        }
    }
}
