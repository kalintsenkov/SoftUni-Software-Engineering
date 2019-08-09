namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Riders.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int RequiredNameSymbols = 5;
        private const int RequiredLaps = 1;

        private readonly List<IRider> riders;

        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < RequiredNameSymbols)
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessages.InvalidName,
                            this.Name,
                            RequiredNameSymbols));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < RequiredLaps)
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessages.InvalidNumberOfLaps,
                            RequiredLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
            => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(
                    ExceptionMessages.RiderInvalid);
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.RiderNotParticipate,
                        rider.Name));
            }

            if (this.riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(
                    string.Format(
                        ExceptionMessages.RiderAlreadyAdded,
                        rider.Name,
                        this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
