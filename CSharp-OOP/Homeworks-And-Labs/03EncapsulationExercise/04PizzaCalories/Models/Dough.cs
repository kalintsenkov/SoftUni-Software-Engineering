namespace PizzaCalories.Models
{
    using System;

    using Exceptions;

    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(
            string flourType, 
            string bakingTechnique, 
            double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidDoughTypeException);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidDoughTypeException);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidDoughWeightException);
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram => 
            2 * this.Weight 
            * this.GetFlourTypeModifier() 
            * this.GetBakingTechniqueModifier();

        private double GetFlourTypeModifier()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return 1.5;
            }

            return 1.0;
        }

        private double GetBakingTechniqueModifier()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1.0;
            }
        }
    }
}
