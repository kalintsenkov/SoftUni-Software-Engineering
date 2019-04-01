using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            decimal lightsaberPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());

            decimal totalLightsabersPrice = lightsaberPrice * Math.Ceiling(studentsCount + studentsCount * 0.10m);
            decimal totalRobesPrice = robePrice * studentsCount;
            decimal freeBelts = studentsCount - studentsCount / 6;
            decimal totalBeltsPrice = beltPrice * freeBelts;

            decimal equipmentPrice = totalLightsabersPrice + totalRobesPrice + totalBeltsPrice;

            if(equipmentPrice <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {equipmentPrice-amountOfMoney:f2}lv more.");
            }
        }
    }
}
