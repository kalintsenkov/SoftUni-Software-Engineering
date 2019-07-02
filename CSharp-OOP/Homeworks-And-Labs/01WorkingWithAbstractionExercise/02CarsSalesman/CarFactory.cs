namespace P02_CarsSalesman
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarFactory
    {
        public Car Create(string[] parameters, List<Engine> engines)
        {
            var model = parameters[0];
            var engineModel = parameters[1];

            var engine = engines
                .FirstOrDefault(x => x.Model == engineModel);

            Car car = null;

            if (parameters.Length == 3)
            {
                var isWeight = int.TryParse(parameters[2], out int weight);

                if (isWeight)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    var color = parameters[2];
                    car =  new Car(model, engine, color);
                }
            }
            else if (parameters.Length == 4)
            {
                var weight = int.Parse(parameters[2]);
                var color = parameters[3];

                car = new Car(model, engine, weight, color);
            }
            else
            {
                car = new Car(model, engine);
            }

            return car;
        }
    }
}