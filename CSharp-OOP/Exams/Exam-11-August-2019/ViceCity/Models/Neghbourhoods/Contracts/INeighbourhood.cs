namespace ViceCity.Models.Neghbourhoods.Contracts
{
    using System.Collections.Generic;

    using Players.Contracts;

    public interface INeighbourhood
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers);
    }
}
