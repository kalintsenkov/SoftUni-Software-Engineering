using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> textsList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string operation = commands[0];

                StringBuilder concatenateText = new StringBuilder();

                if (operation == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    ChekingIndex(textsList, ref startIndex, ref endIndex);

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatenateText.Append(textsList[i]);
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        textsList.RemoveAt(startIndex);
                    }

                    textsList.Insert(startIndex, concatenateText.ToString());

                }
                else if(operation == "divide")
                {
                    // TO DO
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", textsList));
        }

        private static void ChekingIndex(List<string> textsList, ref int startIndex, ref int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            else if (startIndex > textsList.Count - 1)
            {
                startIndex = textsList.Count - 1;
            }
            if (endIndex < 0)
            {
                endIndex = 0;
            }
            else if (endIndex > textsList.Count - 1)
            {
                endIndex = textsList.Count - 1;
            }
        }
    }
}
