namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Cards.Contracts;

    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count 
            => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards 
            => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            this.CheckIfCardIsNull(card);

            if (this.cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
            => this.cards.FirstOrDefault(x => x.Name == name);

        public bool Remove(ICard card)
        {
            this.CheckIfCardIsNull(card);

            return this.cards.Remove(card);
        }

        private void CheckIfCardIsNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
