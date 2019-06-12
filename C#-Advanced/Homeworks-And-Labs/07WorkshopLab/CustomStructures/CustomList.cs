namespace CustomStructures
{
    using System;

    public class CustomList
    {
        private const int defaultSize = 2;
        private int[] elements;

        public int Count { get; private set; }

        public CustomList()
        {
            this.Count = 0;
            this.elements = new int[defaultSize];
        }

        public CustomList(int initialSize)
            : this()
        {
            this.elements = new int[initialSize];
        }

        public int this[int index]
        {
            get
            {
                CheckIndexOutOfRange(index);
                return this.elements[index];
            }
            set
            {
                CheckIndexOutOfRange(index);
                this.elements[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.elements.Length == this.Count)
            {
                Resize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void AddRange(int[] list)
        {
            if (list.Length + this.Count >= this.elements.Length)
            {
                if (list.Length + this.Count > this.elements.Length * 2)
                {
                    Resize((list.Length + this.Count) * 2);
                }
                else
                {
                    Resize();
                }

                for (int i = 0; i < list.Length; i++)
                {
                    this.elements[this.Count] = list[i];
                    this.Count++;
                }
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndexOutOfRange(index);
            ShiftLeft(index);
            Shrink();

            this.Count--;
        }

        public void InsertAt(int index, int element)
        {
            CheckIndexOutOfRange(index);
            ShiftRight(index);

            this.elements[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexOutOfRange(firstIndex);
            CheckIndexOutOfRange(secondIndex);

            int tempElement = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = tempElement;
        }

        public void Shrink()
        {
            if (this.elements.Length / 4 > this.Count)
            {
                var temp = new int[this.elements.Length / 2];

                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.elements[i];
                }

                this.elements = temp;
            }
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.elements[i]);
            }
        }

        private void CheckIndexOutOfRange(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Resize()
        {
            Resize(this.elements.Length * 2);
        }

        private void Resize(int newSize)
        {
            var newValues = new int[newSize];

            for (int i = 0; i < elements.Length; i++)
            {
                newValues[i] = this.elements[i];
            }

            this.elements = newValues;
        }

        private void ShiftLeft(int index)
        {
            if (index < this.Count - 1)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.elements[i] = this.elements[i + 1];
                }
            }

            this.elements[index] = default;
        }

        private void ShiftRight(int index)
        {
            if (this.elements.Length == this.Count)
            {
                Resize();
            }

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.elements[i + 1] = this.elements[i];
            }

            this.elements[index] = default;
        }
    }
}
