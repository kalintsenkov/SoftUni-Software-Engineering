using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());

            int spendTimeCount = 0;
            int daysCount = 0;

            while (ownedMoney < neededMoney && spendTimeCount < 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if(command == "spend")
                {
                    spendTimeCount++;
                    ownedMoney = ownedMoney - money;
                    
                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                }
                else if(command == "save")
                {
                    ownedMoney = ownedMoney + money;
                    spendTimeCount = 0;
                }

                daysCount++;

                if (ownedMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {daysCount} days.");
                }
                if(spendTimeCount == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{daysCount}");
                }
            }
        }
    }
}
