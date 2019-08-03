namespace ParkingSystem.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class SoftParkTest
    {
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void ConsturctorShouldInitializeDictionary()
        {
            Assert.IsNotNull(this.softPark);
        }

        [Test]
        public void ParkCarShouldWorksCorrectly()
        {
            var car = new Car("Audi", "1234");

            this.softPark.ParkCar("A1", car);

            Assert.AreEqual(car, this.softPark.Parking["A1"]);
        }

        [Test]
        public void ParkCarShouldReturnsCorrectMessage()
        {
            var car = new Car("Audi", "1234");

            var actualResult = this.softPark.ParkCar("A1", car);
            var expectedResult = "Car:1234 parked successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfParkSpotIsNotExisting()
        {
            var car = new Car("Audi", "1234");

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("Z1", car));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfParkSpotIsTaken()
        {
            var car = new Car("Audi", "1234");

            this.softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", new Car("Mercedes", "5555")));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfCarIsAlreadyParked()
        {
            var car = new Car("Audi", "1234");

            this.softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("B1", car));
        }

        [Test]
        public void RemoveCarShouldWorksCorrectly()
        {
            var car = new Car("Audi", "1234");

            this.softPark.ParkCar("A1", car);
            this.softPark.RemoveCar("A1", car);

            Assert.IsNull(this.softPark.Parking["A1"]);
        }

        [Test]
        public void RemoveCarShouldReturnsCorrectMessage()
        {
            var car = new Car("Audi", "1234");

            this.softPark.ParkCar("A1", car);

            var actualResult = this.softPark.RemoveCar("A1", car);
            var expectedResult = "Remove car:1234 successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveCarShouldThrowExceptionIfParkingSpotNotExist()
        {
            var car = new Car("Audi", "1234");

            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("Z1", car));
        }

        [Test]
        public void RemoveCarShouldThrowExceptionIfCarNotExist()
        {
            var car = new Car("Audi", "1234");
            var dummyCar = new Car("AlfaRomeo", "5123");

            this.softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", dummyCar));
        }
    }
}