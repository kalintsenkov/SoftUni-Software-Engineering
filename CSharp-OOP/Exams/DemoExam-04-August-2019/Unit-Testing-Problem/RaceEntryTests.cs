namespace TheRace.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorShouldInitializeDictionary()
        {
            Assert.IsNotNull(this.raceEntry);
        }

        [Test]
        public void AddRiderShouldWorksCorrectly()
        {
            var rider = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));

            this.raceEntry.AddRider(rider);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldReturnCorrectMessage()
        {
            var rider = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));

            var actualResult = this.raceEntry.AddRider(rider);
            var expectedResult = "Rider Pesho added in race.";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddRiderShouldThrowExceptionIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void AddRiderShouldThrowExceptionIfRiderIsAlreadyAdded()
        {
            var rider = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));

            this.raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }

        [Test]
        public void CounterShouldWorksCorrectly()
        {
            var rider1 = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));
            var rider2 = new UnitRider("Gosho", new UnitMotorcycle("Suzuki", 40, 55));

            this.raceEntry.AddRider(rider1);
            this.raceEntry.AddRider(rider2);

            var expectedResult = 2;
            var actualResult = this.raceEntry.Counter;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePowerShoudWorksCorrectly()
        {
            var rider1 = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));
            var rider2 = new UnitRider("Gosho", new UnitMotorcycle("Suzuki", 40, 55));

            this.raceEntry.AddRider(rider1);
            this.raceEntry.AddRider(rider2);

            var expectedResult = 37.5;
            var actualResult = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePowerShoudThrowExceptionIfRidersAreLessThan2()
        {
            var rider1 = new UnitRider("Pesho", new UnitMotorcycle("Honda", 35, 50));

            this.raceEntry.AddRider(rider1);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }
    }
}