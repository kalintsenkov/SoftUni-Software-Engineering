namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int length = 8;
        private T[] collection;

        public int Count { get; private set; }

        public Stack()
        {
            this.collection = new T[length];
            this.Count = 0;
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                Resize();
                this.collection[this.Count] = element;
                this.Count++;
            }
        }

        public T Pop()
        {
            CheckIfEmpty();

            var temp = this.collection[this.Count - 1];
            this.collection[this.Count - 1] = default;

            this.Count--;

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Resize()
        {
            if (this.Count == this.collection.Length)
            {
                var resizedArray = new T[this.collection.Length * 2];

                for (int i = 0; i < this.collection.Length; i++)
                {
                    resizedArray[i] = this.collection[i];
                }

                this.collection = resizedArray;
            }
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }
    }
}
