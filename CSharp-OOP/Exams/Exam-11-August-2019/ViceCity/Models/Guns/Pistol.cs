namespace ViceCity.Models.Guns
{
    using System;

    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsPerFire = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel--;

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = Math.Min(this.TotalBullets, InitialBulletsPerBarrel);
                this.TotalBullets -= this.BulletsPerBarrel;
            }

            return BulletsPerFire;
        }
    }
}
