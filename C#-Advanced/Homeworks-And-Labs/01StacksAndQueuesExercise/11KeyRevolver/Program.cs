using System;
using System.Linq;
using System.Collections.Generic;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            var bulletsArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var locksArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int inteligenceValue = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsArray);
            var locks = new Queue<int>(locksArray);

            int barrelsCounter = 0;

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    barrelsCounter++;
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    barrelsCounter++;
                }

                if (bullets.Any() && barrelsCounter % gunBarrelSize == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int totalMoneyForBullets = barrelsCounter * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligenceValue - totalMoneyForBullets}");
            }
        }
    }
}
