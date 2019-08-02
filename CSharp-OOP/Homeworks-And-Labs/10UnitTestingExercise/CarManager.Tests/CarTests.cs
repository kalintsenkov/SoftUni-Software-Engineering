namespace Tests
{
    using System;

    using CarManager;

    using NUnit.Framework;

    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("Mercedes", "S63", 7.5, 50.0);
        }

        [Test]
        public void CarShouldBeCreatedSuccessfully()
        {
            var expectedMake = "Mercedes";
            var expectedModel = "S63";
            var expectedFuelConsumption = 7.5;
            var expectedFuelCapacity = 50.0;

            Assert.That(this.car.Make, Is.EqualTo(expectedMake));
            Assert.That(this.car.Model, Is.EqualTo(expectedModel));
            Assert.That(this.car.FuelConsumption, Is.EqualTo(expectedFuelConsumption));
            Assert.That(this.car.FuelCapacity, Is.EqualTo(expectedFuelCapacity));
        }

        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldThrowExceptionIfIsSetToNull(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "S63", 7.5, 50.0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldThrowExceptionIfIsSetToNull(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", model, 7.5, 50.0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void CarFuelConsumptionShouldThrowExceptionIfIsNegativeOrZero(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "S63", fuelConsumption, 50.0));
        }

        [Test]
        public void CarFuelAmountShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(12));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void CarFuelCapacityShouldThrowExceptionIfIsNegativeOrZero(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "S63", 7.5, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarRefuelShouldThrowExceptionIfFuelIsNegativeOrZero(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        public void CarRefuelShouldIncreaseFuelAmount()
        {
            this.car.Refuel(10);
            var expectedResult = 10;
            var actualResult = this.car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            this.car.Refuel(65);
            var expectedResult = 50;
            var actualResult = this.car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CarDriveMethodShouldDecreaseFuelAmount()
        {
            this.car.Refuel(10);
            this.car.Drive(10);
            var expectedResult = 9.25;
            var actualResult = this.car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CarDriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            this.car.Refuel(2);

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(30));
        }
    }
}