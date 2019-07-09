namespace PersonsInfo
{
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
            => this.firstTeam.AsReadOnly();

        public IReadOnlyList<Person> ReserveTeam
            => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"First team has {this.FirstTeam.Count} players.");
            result.AppendLine($"Reserve team has {this.ReserveTeam.Count} players.");

            return result.ToString().TrimEnd();
        }
    }
}
