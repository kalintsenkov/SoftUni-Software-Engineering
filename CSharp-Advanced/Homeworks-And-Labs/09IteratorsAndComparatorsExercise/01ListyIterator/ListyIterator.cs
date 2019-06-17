namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
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

        private void CheckIfEmpty()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
