namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;

        public Engineer(
            int id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
            => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                result.AppendLine($"  {repair}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
