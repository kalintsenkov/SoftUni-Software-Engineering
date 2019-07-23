namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class DentalCare : Procedure
    {
        private const int AdditionalHappines = 12;
        private const int AdditionalEnergy = 10; 

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTime);
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += AdditionalHappines;
            animal.Energy += AdditionalEnergy;
        }
    }
}
