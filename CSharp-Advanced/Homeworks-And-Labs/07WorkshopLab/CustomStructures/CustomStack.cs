namespace CustomStructures
{
    using System;

    public class CustomStack
    {
        private const int defaultSize = 4;
        private int[] elements;

        public int Count { get; private set; }

        public CustomStack()
        {
            this.Count = 0;
            this.elements = new int[defaultSize];
        }

        public void Push(int element)
        {
            if (this.elements.Length == this.Count)
            {
                Resize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public int Peek()
        {
            CheckStackCount();

            return this.elements[this.Count - 1];
        }

        public int Pop()
        {
            CheckStackCount();

            this.Count--;

            int tempElement = this.elements[this.Count];
            this.elements[this.Count] = default;

            return tempElement;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.elements[i]);
            }
        }

        private void Resize()
        {
            var newValues = new int[this.elements.Length * 2];

            for (int i = 0; i < elements.Length; i++)
            {
                newValues[i] = this.elements[i];
            }

            this.elements = newValues;
        }

        private void CheckStackCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}
