namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(
            int id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions 
            => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                result.AppendLine($"  {mission}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
