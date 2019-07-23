namespace AnimalCentre.Models.Entities.Procedures
{
    using System;

    using Contracts;
    using Exceptions;

    public class Vaccinate : Procedure
    {
        private const int DecreasedEnergy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughProcedureTimeException);
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Energy -= DecreasedEnergy;
            animal.IsVaccinated = true;
        }
    }
}
