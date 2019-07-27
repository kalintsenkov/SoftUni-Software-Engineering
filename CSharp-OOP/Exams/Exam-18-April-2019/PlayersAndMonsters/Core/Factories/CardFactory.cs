namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name == $"{type}Card" && !x.IsAbstract)
                .FirstOrDefault();

            if (cardType == null)
            {
                throw new ArgumentException("Invalid card type!");
            }

            var card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
