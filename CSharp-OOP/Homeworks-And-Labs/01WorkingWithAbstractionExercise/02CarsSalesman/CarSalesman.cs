namespace P02_CarsSalesman
{
    using System.Collections;
    using System.Collections.Generic;

    public class CarSalesman : IEnumerable<Car>
    {
        private List<Car> cars;
        private List<Engine> engines;

        private EngineFactory engineFactory;
        private CarFactory carFactory;

        public CarSalesman(
            EngineFactory engineFactory,
            CarFactory carFactory)
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
            this.engineFactory = engineFactory;
            this.carFactory = carFactory;
        }

        public void AddEngine(string[] parameters)
        {
            var engine = this.engineFactory.Create(parameters);

            this.engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            var car = this.carFactory.Create(parameters, this.engines);

            this.cars.Add(car);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in this.cars)
            {
                yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
