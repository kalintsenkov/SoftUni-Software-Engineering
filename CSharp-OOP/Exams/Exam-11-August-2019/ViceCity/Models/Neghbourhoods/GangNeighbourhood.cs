namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var gun = mainPlayer
                    .GunRepository
                    .Models
                    .FirstOrDefault(x => x.CanFire);

                if (gun == null)
                {
                    break;
                }

                var civilPlayer = civilPlayers
                    .FirstOrDefault(x => x.IsAlive);

                if (civilPlayer == null)
                {
                    break;
                }

                var damagePoints = gun.Fire();
                civilPlayer.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                var civilPlayer = civilPlayers
                    .FirstOrDefault(x => x.IsAlive);

                if (civilPlayer == null)
                {
                    break;
                }

                var gun = civilPlayer
                    .GunRepository
                    .Models
                    .FirstOrDefault(x => x.CanFire);

                if (gun == null)
                {
                    break;
                }

                var damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
