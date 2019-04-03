using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string pattern = @"^(?<artist>^[A-Z][a-z ']*)\:(?<song>[A-Z ]+[ ]*)$";

                Regex validLines = new Regex(pattern);

                if (validLines.IsMatch(input))
                {
                    string artist = validLines.Match(input).Groups["artist"].Value;
                    string song = validLines.Match(input).Groups["song"].Value;

                    StringBuilder encryptedArtist = new StringBuilder();
                    StringBuilder encryptedSong = new StringBuilder();

                    int key = artist.Length;

                    foreach (var symbol in artist)
                    {
                        if (symbol == ' ')
                        {
                            encryptedArtist.Append(' ');
                        }
                        else if (symbol == '\'')
                        {
                            encryptedArtist.Append('\'');
                        }
                        else
                        {
                            if (char.IsUpper(symbol))
                            {
                                if (key + (int)symbol > 90)
                                {
                                    char encryptedSymbol = MakingUpperSymbol(key, symbol);

                                    encryptedArtist.Append(encryptedSymbol);
                                }
                                else
                                {
                                    char encryptedSymbol = (char)(symbol + key);

                                    encryptedArtist.Append(encryptedSymbol);
                                }
                            }
                            else
                            {
                                if (key + (int)symbol > 122)
                                {
                                    char encryptedSymbol = MakingLowerSymbol(key, symbol);

                                    encryptedArtist.Append(encryptedSymbol);
                                }
                                else
                                {
                                    char encryptedSymbol = (char)(symbol + key);

                                    encryptedArtist.Append(encryptedSymbol);
                                }
                            }
                        }
                    }

                    foreach (var symbol in song)
                    {
                        if (symbol == ' ')
                        {
                            encryptedSong.Append(' ');
                        }
                        else
                        {
                            if (char.IsUpper(symbol))
                            {
                                if (key + (int)symbol > 90)
                                {
                                    char encryptedSymbol = MakingUpperSymbol(key, symbol);

                                    encryptedSong.Append(encryptedSymbol);
                                }
                                else
                                {
                                    char encryptedSymbol = (char)(symbol + key);

                                    encryptedSong.Append(encryptedSymbol);
                                }
                            }
                            else
                            {
                                if (key + (int)symbol > 122)
                                {
                                    char encryptedSymbol = MakingLowerSymbol(key, symbol);

                                    encryptedSong.Append(encryptedSymbol);
                                }
                                else
                                {
                                    char encryptedSymbol = (char)(symbol + key);

                                    encryptedSong.Append(encryptedSymbol);
                                }
                            }
                        }
                    }

                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        public static char MakingLowerSymbol(int key, char symbol)
        {
            char encryptedSymbol = symbol;

            for (int i = 0; i < key; i++)
            {
                encryptedSymbol = (char)(encryptedSymbol + 1);
                if (encryptedSymbol > 122)
                {
                    encryptedSymbol = 'a';
                }
            }

            return encryptedSymbol;
        }

        public static char MakingUpperSymbol(int key, char symbol)
        {
            char encryptedSymbol = symbol;

            for (int i = 0; i < key; i++)
            {
                encryptedSymbol = (char)(encryptedSymbol + 1);
                if (encryptedSymbol > 90)
                {
                    encryptedSymbol = 'A';
                }
            }

            return encryptedSymbol;
        }
    }
}
