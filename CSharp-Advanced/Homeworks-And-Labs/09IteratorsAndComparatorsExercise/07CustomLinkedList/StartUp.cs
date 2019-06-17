using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            var linkedList = new CustomLinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
