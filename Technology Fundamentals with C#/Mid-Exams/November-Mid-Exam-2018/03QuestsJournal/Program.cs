using System;
using System.Linq;
using System.Collections.Generic;

namespace _03QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> questsList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Retire!")
            {
                List<string> commands = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string operation = commands[0];

                if (operation == "Start")
                {
                    string quest = commands[1];

                    if (!questsList.Contains(quest))
                    {
                        questsList.Add(quest);
                    }
                }
                else if (operation == "Complete")
                {
                    string quest = commands[1];

                    if (questsList.Contains(quest))
                    {
                        questsList.Remove(quest);
                    }
                }
                else if (operation == "Side Quest")
                {
                    List<string> sideQuestList = commands[1].Split(":").ToList();

                    string quest = sideQuestList[0];
                    string sideQuest = sideQuestList[1];

                    int indexOfQuest = questsList.IndexOf(quest);

                    if (questsList.Contains(quest))
                    {
                        if (!questsList.Contains(sideQuest))
                        {
                            questsList.Insert(indexOfQuest + 1, sideQuest);
                        }
                    }
                }
                else if (operation == "Renew")
                {
                    string quest = commands[1];

                    if (questsList.Contains(quest))
                    {
                        questsList.Remove(quest);
                        questsList.Add(quest);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", questsList));
        }
    }
}
