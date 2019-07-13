namespace Animals
{
    using System.Text;

    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ExplainSelf()}");
            result.AppendLine("MEEOW");

            return result.ToString().TrimEnd();
        }
    }
}
