namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class Chip : Procedure
    {
        private const int DecreasedHappines = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            if (animal.IsChipped)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.AnimalAlreadyChippedException, animal.Name));
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= DecreasedHappines;
            animal.IsChipped = true;
        }
    }
}
