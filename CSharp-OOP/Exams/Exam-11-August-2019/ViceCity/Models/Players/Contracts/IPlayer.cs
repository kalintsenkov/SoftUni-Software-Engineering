namespace ViceCity.Models.Players.Contracts
{
    using Guns.Contracts;
    using Repositories.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        bool IsAlive { get; }

        IRepository<IGun> GunRepository { get; }

        int LifePoints { get; }

        void TakeLifePoints(int points);
    }
}
