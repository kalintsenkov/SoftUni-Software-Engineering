using System;

namespace _04BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            TimeSpan timeAfer30 = new TimeSpan(hours, minutes + 30, 0);
            Console.WriteLine(timeAfer30.ToString(@"h\:mm"));
        }
    }
}
