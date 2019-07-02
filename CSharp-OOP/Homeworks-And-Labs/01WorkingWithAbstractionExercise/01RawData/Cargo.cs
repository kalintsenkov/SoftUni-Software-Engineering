namespace P01_RawData
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight { get; private set; }

        public string Type { get; private set; }
    }
}
