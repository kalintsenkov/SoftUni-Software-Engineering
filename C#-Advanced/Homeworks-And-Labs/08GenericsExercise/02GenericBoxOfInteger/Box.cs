namespace _02GenericBoxOfInteger
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

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var value in values)
            {
                result.AppendLine($"{value.GetType()}: {value}");
            }

            return result.ToString();
        }
    }
}