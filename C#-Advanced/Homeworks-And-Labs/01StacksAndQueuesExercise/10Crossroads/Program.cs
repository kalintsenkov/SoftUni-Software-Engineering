using System;
using System.Collections.Generic;
using System.Linq;

namespace _10Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();

            int passedCarsCounter = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int greenLight = greenLightSeconds;
                    int freeWindow = freeWindowSeconds;

                    while (carsQueue.Any())
                    {
                        string currentCar = carsQueue.Peek();

                        if (greenLight >= currentCar.Length)
                        {
                            greenLight -= currentCar.Length;
                            carsQueue.Dequeue();
                            passedCarsCounter++;
                        }
                        else if (greenLight <= 0)
                        {
                            break;
                        }
                        else if (greenLight < currentCar.Length)
                        {
                            if (greenLight + freeWindow >= currentCar.Length)
                            {
                                greenLight = 0;
                                freeWindow -= currentCar.Length;
                                carsQueue.Dequeue();
                                passedCarsCounter++;
                            }
                            else
                            {
                                int indexOfCrash = greenLight + freeWindow;

                                if (indexOfCrash >= 0 && indexOfCrash < currentCar.Length)
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[indexOfCrash]}.");
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
        }
    }
}
