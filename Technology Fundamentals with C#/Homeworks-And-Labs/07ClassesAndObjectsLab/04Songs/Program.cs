using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Songs
{
    public class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var songsList = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string typeList = tokens[0];
                string name = tokens[1];
                string time = tokens[2];

                var song = new Song
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time
                };

                songsList.Add(song);
            }

            string command = Console.ReadLine();

            if(command == "all")
            {
                foreach (var song in songsList)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songsList.Where(x => x.TypeList == command))
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
