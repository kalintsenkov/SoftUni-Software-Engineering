namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index + 1 < this.elements.Count)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.elements.Count)
            {
                return true;
            }

            return false;
        }

        public T Print()
        {
            CheckIfEmpty();

            return this.elements[index];
        }

        public string PrintAll()
        {
            CheckIfEmpty();

            return string.Join(" ", this.elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void CheckIfEmpty()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}