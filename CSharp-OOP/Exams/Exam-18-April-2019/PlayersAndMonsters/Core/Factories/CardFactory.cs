namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Cards;
    using Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if (type == "Trap")
            {
                card = new TrapCard(name);
            }

            return card;
        }
    }
}
