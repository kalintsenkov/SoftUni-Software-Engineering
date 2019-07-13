namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Contracts;
    using Exceptions;
    using Models;

    public class Engine
    {
        private readonly List<ISoldier> soldiers;

        private readonly CommandParser commandParser;

        public Engine(CommandParser commandParser)
        {
            this.commandParser = commandParser;
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var command = this.commandParser.Parse(input);

                try
                {
                    this.AddSoldiers(command);
                }
                catch (InvalidCorpsException)
                {
                }
                catch (InvalidMissionException)
                {
                }

                input = Console.ReadLine();
            }

            this.PrintSoldiers();
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private void AddSoldiers(Command command)
        {
            if (command.Name == "Private")
            {
                var @private = this.CreatePrivate(command.Arguments);
                this.soldiers.Add(@private);
            }
            else if (command.Name == "LieutenantGeneral")
            {
                var lieutenant = this.CreateLieutenant(command.Arguments);
                this.soldiers.Add(lieutenant);
            }
            else if (command.Name == "Engineer")
            {
                var engineer = this.CreateEngineer(command.Arguments);
                this.soldiers.Add(engineer);
            }
            else if (command.Name == "Commando")
            {
                var commando = this.CreateCommando(command.Arguments);
                this.soldiers.Add(commando);
            }
            else if (command.Name == "Spy")
            {
                var spy = this.CreateSpy(command.Arguments);
                this.soldiers.Add(spy);
            }
        }

        private ISoldier CreateCommando(string[] arguments)
        {
            var id = int.Parse(arguments[0]);
            var firstName = arguments[1];
            var lastName = arguments[2];
            var salary = decimal.Parse(arguments[3]);
            var corps = arguments[4];

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            var missions = arguments
                .Skip(5)
                .ToList();

            for (int i = 0; i < missions.Count; i += 2)
            {
                try
                {
                    var missionCodeName = missions[i];
                    var missionState = missions[i + 1];

                    IMission mission = new Mission(missionCodeName, missionState);
                    commando.AddMission(mission);
                }
                catch (InvalidStateException)
                {
                    continue;
                }
            }

            return commando;
        }

        private ISoldier CreateSpy(string[] arguments)
        {
            var id = int.Parse(arguments[0]);
            var firstName = arguments[1];
            var lastName = arguments[2];
            var codeNumber = int.Parse(arguments[3]);

            return new Spy(id, firstName, lastName, codeNumber);
        }

        private ISoldier CreateEngineer(string[] arguments)
        {
            var id = int.Parse(arguments[0]);
            var firstName = arguments[1];
            var lastName = arguments[2];
            var salary = decimal.Parse(arguments[3]);
            var corps = arguments[4];

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            var repairs = arguments
                .Skip(5)
                .ToList();

            for (int i = 0; i < repairs.Count; i += 2)
            {
                var repairPartName = repairs[i];
                var repairHours = int.Parse(repairs[i + 1]);

                IRepair repair = new Repair(repairPartName, repairHours);

                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier CreateLieutenant(string[] arguments)
        {
            var id = int.Parse(arguments[0]);
            var firstName = arguments[1];
            var lastName = arguments[2];
            var salary = decimal.Parse(arguments[3]);

            ILieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);

            var ids = arguments
                .Skip(4)
                .Select(int.Parse)
                .ToList();

            foreach (var currentId in ids)
            {
                ISoldier @private = this.soldiers.FirstOrDefault(x => x.Id == currentId);

                lieutenant.AddPrivate(@private);
            }

            return lieutenant;
        }

        private ISoldier CreatePrivate(string[] arguments)
        {
            var id = int.Parse(arguments[0]);
            var firstName = arguments[1];
            var lastName = arguments[2];
            var salary = decimal.Parse(arguments[3]);

            return new Private(id, firstName, lastName, salary);
        }
    }
}
