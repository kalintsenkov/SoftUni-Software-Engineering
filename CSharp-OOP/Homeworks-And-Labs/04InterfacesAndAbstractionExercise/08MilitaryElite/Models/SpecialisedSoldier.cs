namespace MilitaryElite.Models
{
    using System;
    using System.Text;
    using Contracts;
    using Enumerations;
    using Exceptions;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(
            int id, 
            string firstName, 
            string lastName, 
            decimal salary,
            string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine($"Corps: {this.Corps.ToString()}");

            return result.ToString().TrimEnd();
        }

        private void ParseCorps(string corpsStr)
        {
            var parsed = Enum.TryParse(corpsStr, out Corps corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }
    }
}
