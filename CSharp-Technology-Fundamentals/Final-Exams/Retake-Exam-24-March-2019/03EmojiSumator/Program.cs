using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var emojiCode = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string pattern = @"(?<=\s)(?<emoji>:[a-z]{4,}:)(?=[\s,.!?])";

            var validEmoji = Regex.Matches(input, pattern);
            var emojiList = new List<string>();
            int totalEmojiPower = 0;

            foreach (Match emoji in validEmoji)
            {
                emojiList.Add(emoji.ToString());

                foreach (var symbol in emoji.ToString())
                {
                    if (symbol != ':')
                    {
                        totalEmojiPower += symbol;
                    }
                }
            }

            foreach (var emoji in emojiList)
            {
                int currentEmojiPower = 0;

                foreach (var character in emoji)
                {
                    if (character != ':')
                    {
                        currentEmojiPower += character;
                    }
                }

                if (currentEmojiPower == emojiCode.Sum())
                {
                    totalEmojiPower *= 2;
                }
            }

            if (emojiList.Count > 0)
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emojiList)}");
            }

            Console.WriteLine($"Total Emoji Power: {totalEmojiPower}");
        }
    }
}
