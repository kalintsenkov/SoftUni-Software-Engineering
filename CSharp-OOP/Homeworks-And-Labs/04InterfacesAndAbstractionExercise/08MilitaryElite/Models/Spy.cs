namespace MilitaryElite.Models
{
    using System.Text;
    using Contracts;

    public class Spy : Soldier, ISpy
    {
        public Spy(
            int id, 
            string firstName, 
            string lastName,
            int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine($"Code Number: {this.CodeNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
