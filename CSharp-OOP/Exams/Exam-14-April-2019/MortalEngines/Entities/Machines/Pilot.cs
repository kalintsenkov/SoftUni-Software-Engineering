namespace MortalEngines.Entities.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Pilot : IPilot
    {
        private readonly IList<IMachine> machines;

        private string name;

        public Pilot(string name)
        {
            this.Name = name;

            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {
                result.AppendLine($"{machine}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
