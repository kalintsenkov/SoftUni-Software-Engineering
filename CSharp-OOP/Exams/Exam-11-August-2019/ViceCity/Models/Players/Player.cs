namespace ViceCity.Models.Players
{
    using System;

    using Contracts;
    using Guns.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;

            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        ExceptionMessages.InvalidPlayerName);
                }

                this.name = value;
            }
        }

        public bool IsAlive
            => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidPlayerLifePoints);
                }

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points < 0)
            {
                this.LifePoints = 0;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}
