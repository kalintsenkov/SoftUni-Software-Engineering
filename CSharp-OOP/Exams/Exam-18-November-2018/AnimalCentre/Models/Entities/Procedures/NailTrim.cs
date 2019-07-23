namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class NailTrim : Procedure
    {
        private const int DecreasedHappiness = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= DecreasedHappiness;
        }
    }
}
