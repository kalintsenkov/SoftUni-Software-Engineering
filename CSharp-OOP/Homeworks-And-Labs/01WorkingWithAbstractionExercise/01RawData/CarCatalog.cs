namespace P01_RawData
{
    using System.Collections;
    using System.Collections.Generic;

    public class CarCatalog : IEnumerable<Car>
    {
        private const int TireCount = 4;

        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public void Add(string[] parameters)
        {
            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);

            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];

            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new Tire[TireCount]
            {
                new Tire(double.Parse(parameters[5]), int.Parse(parameters[6])),
                new Tire(double.Parse(parameters[7]), int.Parse(parameters[8])),
                new Tire(double.Parse(parameters[9]), int.Parse(parameters[10])),
                new Tire(double.Parse(parameters[11]), int.Parse(parameters[12]))
            };

            this.cars.Add(new Car(model, engine, cargo, tires));
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in this.cars)
            {
                yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}
