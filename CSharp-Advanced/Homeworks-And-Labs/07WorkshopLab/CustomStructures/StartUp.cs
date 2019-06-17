using System;

namespace CustomStructures
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new CustomList();

            list.Add(1);
            list.Add(3);
            list.Add(5);

            list.AddRange(new int[] { 11, 21, 52, 33, 45, 65, 91, 71 });
            list.RemoveAt(3);
            
            //list.InsertAt(100, 51);
            
            list.InsertAt(4, 8);
            list.Swap(0, 8);

            list.ForEach(Console.WriteLine);
        }
    }
}
