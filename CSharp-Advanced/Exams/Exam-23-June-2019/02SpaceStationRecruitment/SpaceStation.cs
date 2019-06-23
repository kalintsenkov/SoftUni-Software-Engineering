namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.astronauts.Any(x => x.Name == name))
            {
                var astronaut = this.astronauts
                    .FirstOrDefault(x => x.Name == name);

                this.astronauts.Remove(astronaut);

                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
            => this.astronauts
            .OrderByDescending(x => x.Age)
            .FirstOrDefault();

        public Astronaut GetAstronaut(string name)
            => this.astronauts
            .FirstOrDefault(x => x.Name == name);

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.astronauts)
            {
                result.AppendLine(astronaut.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
