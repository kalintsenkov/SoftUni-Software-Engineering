namespace Ferrari.Models
{
    public class Ferrari : Car
    {
        public Ferrari(string driverName) 
            : base(driverName)
        {
        }

        public override string Model => "488-Spider";
    }
}
