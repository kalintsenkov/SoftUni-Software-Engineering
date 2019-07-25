namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using Entities.Contracts;
    using Entities.Machines;
    using Factories.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IPilot> pilots;
        private readonly IList<IMachine> machines;

        private readonly IPilotFactory pilotFactory;
        private readonly ITankFactory tankFactory;
        private readonly IFighterFactory fighterFactory;

        public MachinesManager(
            IPilotFactory pilotFactory,
            ITankFactory tankFactory,
            IFighterFactory fighterFactory)
        {
            this.pilotFactory = pilotFactory;
            this.tankFactory = tankFactory;
            this.fighterFactory = fighterFactory;

            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            var pilot = this.pilotFactory.CreatePilot(name);

            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var tank = this.tankFactory.CreateTank(name, attackPoints, defensePoints);

            this.machines.Add(tank);

            return string.Format(
                OutputMessages.TankManufactured, 
                name,
                tank.AttackPoints,
                tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var fighter = this.fighterFactory.CreateFighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return string.Format(
                OutputMessages.FighterManufactured,
                name,
                fighter.AttackPoints,
                fighter.DefensePoints,
                fighter.AggressiveMode ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null || defendingMachine == null)
            {
                var machineName = attackingMachine == null ? attackingMachineName : defendingMachineName;

                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            if (attackingMachine.HealthPoints == 0 || defendingMachine.HealthPoints == 0)
            {
                var machineName = attackingMachine.HealthPoints == 0 ? attackingMachineName : defendingMachineName;

                return string.Format(OutputMessages.DeadMachineCannotAttack, machineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(
                OutputMessages.AttackSuccessful,
                defendingMachine.Name, 
                attackingMachine.Name,
                defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(x => x.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter)this.machines
                .FirstOrDefault(x => x.Name == fighterName && x.GetType() == typeof(Fighter));

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (ITank)this.machines
                .FirstOrDefault(x => x.Name == tankName && x.GetType() == typeof(Tank));

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}