namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            var index = this.random.Next(0, this.Count);
            var element = this[index];
            this.RemoveAt(index);

            return element;
        }
    }
}
