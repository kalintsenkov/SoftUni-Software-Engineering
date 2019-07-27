namespace PlayersAndMonsters.Core
{
    using System.Text;

    using Common;
    using Contracts;
    using Factories.Contracts;
    using Models.BattleFields.Contracts;
    using Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;

        private readonly IBattleField battleField;

        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;

        public ManagerController(
            IPlayerRepository playerRepository,
            ICardRepository cardRepository,
            IBattleField battleField,
            IPlayerFactory playerFactory,
            ICardFactory cardFactory)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(
                ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(
                ConstantMessages.SuccessfullyAddedPlayerWithCards, 
                cardName, 
                username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playerRepository.Find(attackUser);
            var enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(
                ConstantMessages.FightInfo,
                attackPlayer.Health,
                enemyPlayer.Health);
        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                result.AppendLine($"{player}");

                foreach (var card in player.CardRepository.Cards)
                {
                    result.AppendLine($"{card}");
                }

                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return result.ToString().TrimEnd();
        }
    }
}
