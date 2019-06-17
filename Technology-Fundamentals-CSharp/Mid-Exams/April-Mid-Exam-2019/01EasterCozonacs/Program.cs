using System;

namespace _01EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal OneKgFlourPrice = decimal.Parse(Console.ReadLine());

            decimal packOfEggsPrice = OneKgFlourPrice * 0.75m;
            decimal milkPriceForOneLiter = OneKgFlourPrice + OneKgFlourPrice * 0.25m;
            decimal milkPrice = milkPriceForOneLiter * 0.250m;

            decimal oneCozonacPrice = OneKgFlourPrice + packOfEggsPrice + milkPrice;

            int coloredEggsCounter = 0;
            int cozonacsCounter = 0;

            while (budget >= oneCozonacPrice)
            {
                budget -= oneCozonacPrice;
                coloredEggsCounter += 3;
                cozonacsCounter++;

                if (cozonacsCounter % 3 == 0)
                {
                    int losedEggs = cozonacsCounter - 2;
                    coloredEggsCounter -= losedEggs;
                }
            }

            Console.WriteLine($"You made {cozonacsCounter} cozonacs! Now you have {coloredEggsCounter} eggs and {budget:f2}BGN left.");
        }
    }
}
