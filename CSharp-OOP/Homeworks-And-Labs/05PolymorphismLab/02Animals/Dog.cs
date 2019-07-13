namespace Animals
{
    using System.Text;

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var result = new StringBuilder();

            result.AppendLine($"{base.ExplainSelf()}");
            result.AppendLine("DJAAF");

            return result.ToString().TrimEnd();
        }
    }
}
