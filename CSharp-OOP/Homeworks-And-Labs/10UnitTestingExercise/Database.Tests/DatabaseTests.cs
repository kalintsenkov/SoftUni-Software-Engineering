namespace Tests
{
    using System;

    using Database;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
           this.database = new Database(1, 2, 3, 4);
        }

        [Test]
        public void DatabaseCountShouldBeCorrect()
        {
            var actualResult = this.database.Count;
            var expectedResult = 4;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(-3)]
        [TestCase(0)]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int number)
        {
            this.database.Add(number);

            Assert.That(this.database.Count, Is.EqualTo(5));
        }

        [Test]
        public void DatabaseAddMethodShouldThrowException()
        {
            for (int i = 1; i <= 12; i++)
            {
                this.database.Add(17);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(3));
        }

        [Test]
        public void DatabaseRemoveMethodShouldWorkCorrectly()
        {
            this.database.Remove();

            var actualResult = this.database.Count;
            var expectedResult = 3;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseFetchMethodShouldReturnArray()
        {
            var numbers = this.database.Fetch();

            Assert.That(numbers.Length, Is.EqualTo(this.database.Count));
            Assert.That(numbers, Is.InstanceOf(typeof(int[])));
        }
    }
}