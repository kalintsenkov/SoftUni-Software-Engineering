namespace PlayersAndMonsters.Models.Players
{
    using Repositories.Contracts;

    public class Advanced : Player
    {
        private const int InitialHealthPoints = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoints)
        {
        }
    }
}
