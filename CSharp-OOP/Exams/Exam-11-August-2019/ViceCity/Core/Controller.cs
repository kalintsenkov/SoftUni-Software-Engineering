namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Factories.Contracts;
    using Models.Guns.Contracts;
    using Models.Neghbourhoods.Contracts;
    using Models.Players;
    using Models.Players.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private const string MainPlayerName = "Vercetti";

        private readonly List<IPlayer> civilPlayers;
        private readonly Queue<IGun> guns;

        private readonly IPlayer mainPlayer;
        private readonly INeighbourhood neighbourhood;

        private readonly IGunFactory gunFactory;

        public Controller(
            IPlayer mainPlayer,
            INeighbourhood neighbourhood,
            IGunFactory gunFactory)
        {
            this.mainPlayer = mainPlayer;
            this.neighbourhood = neighbourhood;
            this.gunFactory = gunFactory;

            this.civilPlayers = new List<IPlayer>();
            this.guns = new Queue<IGun>();
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);

            this.civilPlayers.Add(player);

            return string.Format(
                OutputMessages.CivilPlayerAdded,
                player.Name);
        }

        public string AddGun(string type, string name)
        {
            var gun = this.gunFactory.CreateGun(type, name);

            this.guns.Enqueue(gun);

            return string.Format(
                OutputMessages.GunAdded,
                gun.Name,
                gun.GetType().Name);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return OutputMessages.EmptyQueue;
            }

            var gun = this.guns.Peek();

            if (name == MainPlayerName)
            {
                this.mainPlayer
                    .GunRepository
                    .Add(this.guns.Dequeue());

                return string.Format(
                    OutputMessages.AddedGunToTheMainPlayer,
                    gun.Name);
            }

            if (!this.civilPlayers.Any(x => x.Name == name))
            {
                return OutputMessages.PlayerDoesNotExists;
            }

            var civilPlayer = this.civilPlayers
                .FirstOrDefault(x => x.Name == name);

            civilPlayer
                .GunRepository
                .Add(this.guns.Dequeue());

            return string.Format(
                OutputMessages.AddedGunToTheCivilPlayer,
                gun.Name,
                civilPlayer.Name);
        }

        public string Fight()
        {
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            var areAllCivilsOk = this.civilPlayers
                .All(x => x.LifePoints == 50);

            var deadCivilPlayers = this.civilPlayers
                .Where(x => !x.IsAlive)
                .Count();

            this.civilPlayers
                .RemoveAll(x => !x.IsAlive);

            if (this.mainPlayer.LifePoints == 100 && areAllCivilsOk)
            {
                return OutputMessages.EverythingIsOk;
            }
            else
            {
                var result = new StringBuilder();

                result.AppendLine("A fight happened:");
                result.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                result.AppendLine($"Tommy has killed: {deadCivilPlayers} players!");
                result.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");

                return result.ToString().TrimEnd();
            }
        }
    }
}
