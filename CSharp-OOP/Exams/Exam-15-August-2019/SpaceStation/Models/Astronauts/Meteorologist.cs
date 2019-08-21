namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int InitialOxygen = 90;

        public Meteorologist(string name) 
            : base(name, InitialOxygen)
        {
        }
    }
}
