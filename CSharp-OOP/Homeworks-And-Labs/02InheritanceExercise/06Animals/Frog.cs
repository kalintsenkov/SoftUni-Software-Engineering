namespace Animals
{
    using System.Text;

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendLine(base.ToString());

            return result.ToString().TrimEnd();
        }
    }
}
