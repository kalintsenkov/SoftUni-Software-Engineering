namespace FootballTeamGenerator.Models
{
    using System;

    public class Stat
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribblе = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribblе
        {
            get => this.dribble;
            private set
            {
                this.ValidateStat(value, nameof(this.Dribblе));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double OverallStat
            => (this.Endurance 
            + this.Sprint 
            + this.Dribblе 
            + this.Passing 
            + this.Shooting) / 5.0;

        private void ValidateStat(int statValue, string statName)
        {
            if (statValue < MinStatValue || statValue > MaxStatValue)
            {
                throw new ArgumentException($"{statName} should be between {MinStatValue} and {MaxStatValue}.");
            }
        }
    }
}