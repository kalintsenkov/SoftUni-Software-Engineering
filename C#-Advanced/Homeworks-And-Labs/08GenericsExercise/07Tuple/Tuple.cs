namespace _07Tuple
{
    public class Tuple<T, V>
    {
        public T Item1 { get; private set; }
        public V Item2 { get; private set; }

        public Tuple(T item1, V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
