namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class Play : Procedure
    {
        private const int DecreasedEnergy = 6;
        private const int AdditionalHappiness = 12;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Energy -= DecreasedEnergy;
            animal.Happiness += AdditionalHappiness;
        }
    }
}
