using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenir = Console.ReadLine();
            int numberSouvenirs = int.Parse(Console.ReadLine());

            double totalMoney = 0;

            if(team == "Argentina")
            {
                switch (souvenir)
                {
                    case "flags":
                        totalMoney = 3.25 * numberSouvenirs;
                        break;
                    case "caps":
                        totalMoney = 7.20 * numberSouvenirs;
                        break;
                    case "posters":
                        totalMoney = 5.10 * numberSouvenirs;
                        break;
                    case "stickers":
                        totalMoney = 1.25 * numberSouvenirs;
                        break;
                    default:
                        Console.WriteLine($"Invalid stock!");
                        return;
                }
                Console.WriteLine($"Pepi bought {numberSouvenirs} {souvenir} of {team} for {totalMoney:F2} lv.");
            }
            else if(team == "Brazil")
            {
                switch (souvenir)
                {
                    case "flags":
                        totalMoney = 4.20 * numberSouvenirs;
                        break;
                    case "caps":
                        totalMoney = 8.50 * numberSouvenirs;
                        break;
                    case "posters":
                        totalMoney = 5.35 * numberSouvenirs;
                        break;
                    case "stickers":
                        totalMoney = 1.20 * numberSouvenirs;
                        break;
                    default:
                        Console.WriteLine($"Invalid stock!");
                        return;
                }
                Console.WriteLine($"Pepi bought {numberSouvenirs} {souvenir} of {team} for {totalMoney:F2} lv.");
            }
            else if (team == "Croatia")
            {
                switch (souvenir)
                {
                    case "flags":
                        totalMoney = 2.75 * numberSouvenirs;
                        break;
                    case "caps":
                        totalMoney = 6.90 * numberSouvenirs;
                        break;
                    case "posters":
                        totalMoney = 4.95 * numberSouvenirs;
                        break;
                    case "stickers":
                        totalMoney = 1.10 * numberSouvenirs;
                        break;
                    default:
                        Console.WriteLine($"Invalid stock!");
                        return;
                }
                Console.WriteLine($"Pepi bought {numberSouvenirs} {souvenir} of {team} for {totalMoney:F2} lv.");
            }
            else if (team == "Denmark")
            {
                switch (souvenir)
                {
                    case "flags":
                        totalMoney = 3.10 * numberSouvenirs;
                        break;
                    case "caps":
                        totalMoney = 6.50 * numberSouvenirs;
                        break;
                    case "posters":
                        totalMoney = 4.80 * numberSouvenirs;
                        break;
                    case "stickers":
                        totalMoney = 0.90 * numberSouvenirs;
                        break;
                    default:
                        Console.WriteLine($"Invalid stock!");
                        return;
                }
                Console.WriteLine($"Pepi bought {numberSouvenirs} {souvenir} of {team} for {totalMoney:F2} lv.");
            }
            else
            {
                Console.WriteLine("Invalid country!");
            }
        }
    }
}
