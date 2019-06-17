using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            var textVersions = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .ToArray();

                int command = int.Parse(tokens[0]);

                if (command == 1)
                {
                    textVersions.Push(text.ToString());
                    string textToAppend = tokens[1];
                    text.Append(textToAppend);
                }
                else if (command == 2)
                {
                    textVersions.Push(text.ToString());

                    int count = int.Parse(tokens[1]);

                    text.Remove(text.Length - count, count);
                }
                else if (command == 3)
                {
                    int index = int.Parse(tokens[1]) - 1;

                    if (index >= 0 && index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }
                else if (command == 4)
                {
                    text.Clear();
                    text.Append(textVersions.Pop());
                }
            }
        }
    }
}
