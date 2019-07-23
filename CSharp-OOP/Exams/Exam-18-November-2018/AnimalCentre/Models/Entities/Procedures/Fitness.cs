namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class Fitness : Procedure
    {
        private const int DecreasedHappines = 3;
        private const int AdditionalEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= DecreasedHappines;
            animal.Energy += AdditionalEnergy;
        }
    }
}
