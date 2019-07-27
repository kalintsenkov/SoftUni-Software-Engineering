namespace PlayersAndMonsters
{
    using Commands;
    using Core;
    using Core.Factories;
    using IO;
    using Models.BattleFields;
    using Repositories;

    public class StartUp
    {
        public static void Main()
        {
            var commandParser = new CommandParser();

            var playerRepository = new PlayerRepository();
            var cardRepository = new CardRepository();
            var battleField = new BattleField();
            var playerFactory = new PlayerFactory();
            var cardFactory = new CardFactory();

            var managerController = new ManagerController(
                playerRepository,
                cardRepository,
                battleField, 
                playerFactory, 
                cardFactory);

            var dataReader = new ConsoleReader();
            var dataWriter = new ConsoleWriter();

            var engine = new Engine(
                commandParser,
                managerController,
                dataReader,
                dataWriter);

            engine.Run();
        }
    }
}