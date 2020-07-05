using System;
using System.Linq;
using System.Text;

namespace _04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (var symbol in text)
            {
                char encryptedSymbol = (char)(symbol + 3);

                sb.Append(encryptedSymbol);
            }

            Console.WriteLine(sb);
        }
    }
}
