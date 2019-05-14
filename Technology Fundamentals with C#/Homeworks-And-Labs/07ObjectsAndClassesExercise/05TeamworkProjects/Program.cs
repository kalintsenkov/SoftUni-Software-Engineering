using System;
using System.Collections.Generic;
using System.Linq;

namespace _05TeamworkProjects
{
    public class Team
    {
        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var teamsList = new List<Team>();

            for (int i = 1; i <= n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creatorName = tokens[0];
                string teamName = tokens[1];

                var team = new Team()
                {
                    Creator = creatorName,
                    TeamName = teamName,
                    Members = new List<string>()
                };

                if (!teamsList.Any(x => x.TeamName == teamName) && !teamsList.Any(x => x.Creator == creatorName))
                {
                    teamsList.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                else if (teamsList.Any(x => x.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                var tokens = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string member = tokens[0];
                string teamName = tokens[1];

                if (teamsList.Any(x => x.TeamName == teamName))
                {
                    int indexOfTeam = teamsList.FindIndex(x => x.TeamName == teamName);

                    if (!teamsList.Any(x => x.Members.Contains(member)) &&
                        !teamsList.Any(x => x.Creator == member))
                    {
                        teamsList[indexOfTeam].Members.Add(member);
                    }
                    else
                    {
                        Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                input = Console.ReadLine();
            }

            var resultTeams = teamsList
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            foreach (var team in resultTeams)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            var disbandTeams = teamsList
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (var team in disbandTeams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
