namespace MXGP.Models.Riders
{
    using System;
    
    using Contracts;
    using Motorcycles.Contracts;
    using Utilities.Messages;

    public class Rider : IRider
    {
        private const int RequiredNameSymbols = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
            this.CanParticipate = false;
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

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            this.Motorcycle = motorcycle ?? throw new ArgumentNullException(
                    ExceptionMessages.MotorcycleInvalid);

            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
