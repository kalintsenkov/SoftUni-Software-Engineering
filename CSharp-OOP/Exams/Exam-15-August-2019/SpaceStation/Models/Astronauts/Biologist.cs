namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;
        private const int OxygenDecreasement = 5;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - OxygenDecreasement > 0)
            {
                this.Oxygen -= OxygenDecreasement;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
