namespace _03GenericSwapMethodString
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Box<T>
    {
        private List<T> values;

        public Box()
        {
            this.values = new List<T>();
        }

        public void Add(T value)
        {
            this.values.Add(value);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIfEmpty();
            CheckIndexOutOfRange(firstIndex, secondIndex);

            var temp = this.values[firstIndex];
            this.values[firstIndex] = this.values[secondIndex];
            this.values[secondIndex] = temp;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var value in this.values)
            {
                result.AppendLine($"{value.GetType()}: {value}");
            }

            return result.ToString();
        }

        private void CheckIfEmpty()
        {
            if (this.values.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
        }

        private void CheckIndexOutOfRange(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.values.Count
                            || secondIndex < 0 && secondIndex >= this.values.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}