namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public ICollection<string> Items { get; }
    }
}
