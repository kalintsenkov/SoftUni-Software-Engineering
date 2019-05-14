using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMaidenParty = double.Parse(Console.ReadLine());
            int numberLoveMessages = int.Parse(Console.ReadLine());
            int numberRoses = int.Parse(Console.ReadLine());
            int numberKeyHolders = int.Parse(Console.ReadLine());
            int numberCaricatures = int.Parse(Console.ReadLine());
            int numberLuckyPrizes = int.Parse(Console.ReadLine());

            double loveMessagesPrice = 0.60;
            double rosesPrice = 7.20;
            double keyholdersPrice = 3.60;
            double caricaturesPrice = 18.20;
            double luckyPrizesPrice = 22;

            double numberArticles = numberLoveMessages + numberRoses + numberKeyHolders + numberCaricatures + numberLuckyPrizes;

            if (numberArticles >= 25)
            {
                double sum = numberLoveMessages * loveMessagesPrice + numberRoses * rosesPrice + numberKeyHolders * keyholdersPrice +
            numberCaricatures * caricaturesPrice + numberLuckyPrizes * luckyPrizesPrice;
                double discount = sum * 0.35;
                double totalPrice = sum - discount;
                double hostingPrice = totalPrice * 0.10;
                double profit = totalPrice - hostingPrice;
                if (profit >= priceMaidenParty)
                {
                    double moneyLeft = profit - priceMaidenParty;
                    Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
                }
                else if (profit < priceMaidenParty)
                {
                    double moneyNeeded = priceMaidenParty - profit;
                    Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
                }
            }
            else if (numberArticles < 25)
            {
                double sum = numberLoveMessages * loveMessagesPrice + numberRoses * rosesPrice + numberKeyHolders * keyholdersPrice +
            numberCaricatures * caricaturesPrice + numberLuckyPrizes * luckyPrizesPrice;
                double hostingPrice = sum * 0.10;
                double profit = sum - hostingPrice;
                if (profit < priceMaidenParty)
                {
                    double moneyNeeded = priceMaidenParty - profit;
                    Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
                }
                else if(profit >= priceMaidenParty)
                {
                    double moneyLeft = profit - priceMaidenParty;
                    Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
                }
            }
        }
    }
}