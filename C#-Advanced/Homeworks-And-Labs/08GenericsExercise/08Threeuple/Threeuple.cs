namespace _08Threeuple
{
    public class Threeuple<T, V, K>
    {
        public T Item1 { get; private set; }

        public V Item2 { get; private set; }

        public K Item3 { get; private set; }

        public Threeuple(T item1, V item2, K item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
