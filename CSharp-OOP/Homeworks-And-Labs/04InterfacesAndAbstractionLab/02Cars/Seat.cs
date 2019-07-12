namespace Cars
{
    using System.Text;

    public class Seat : Car
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine(this.Start());
            result.AppendLine(this.Stop());

            return result.ToString().TrimEnd();
        }
    }
}
