namespace BoxOfT
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
    {
        private List<T> elements;

        public int Count => this.elements.Count;

        public Box()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            var lastElement = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);

            return lastElement;
        }
    }
}
