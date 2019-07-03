namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatDefaultGender = "male";

        public Tomcat(string name, int age) 
            : base(name, age, TomcatDefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
