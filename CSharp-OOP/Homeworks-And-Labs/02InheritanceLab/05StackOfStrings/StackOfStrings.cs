namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(params string[] collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }
        }
    }
}
