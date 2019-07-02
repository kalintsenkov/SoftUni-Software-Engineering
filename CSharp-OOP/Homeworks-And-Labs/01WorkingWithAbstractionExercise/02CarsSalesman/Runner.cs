namespace P02_CarsSalesman
{
    using System;

    public class Runner
    {
        private CarSalesman carSalesman;

        public Runner(CarSalesman carSalesman)
        {
            this.carSalesman = carSalesman;
        }

        public void Start()
        {
            var engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.carSalesman.AddEngine(parameters);
            }

            var carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.carSalesman.AddCar(parameters);
            }

            PrintCars();
        }

        private void PrintCars()
        {
            foreach (var car in this.carSalesman)
            {
                Console.WriteLine(car);
            }
        }
    }
}
