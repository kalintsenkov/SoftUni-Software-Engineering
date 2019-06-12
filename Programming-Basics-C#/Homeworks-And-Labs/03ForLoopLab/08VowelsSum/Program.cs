using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int sumLetters = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                switch (ch)
                {
                    case 'a':
                        sumLetters += 1;
                        break;
                    case 'e':
                        sumLetters += 2;
                        break;
                    case 'i':
                        sumLetters += 3;
                        break;
                    case 'o':
                        sumLetters += 4;
                        break;
                    case 'u':
                        sumLetters += 5;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(sumLetters);
        }
    }
}
