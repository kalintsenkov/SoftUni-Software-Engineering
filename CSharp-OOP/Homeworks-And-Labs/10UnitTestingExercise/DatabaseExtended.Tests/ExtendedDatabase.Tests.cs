namespace Tests
{
    using System;

    using ExtendedDatabase;

    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            var persons = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan_Ivan"),
                new Person(4, "Pesho_ivanov"),
                new Person(5, "Gosho_Naskov"),
                new Person(6, "Pesh-Peshov"),
                new Person(7, "Ivan_Kaloqnov"),
                new Person(8, "Ivan_Draganchov"),
                new Person(9, "Asen"),
                new Person(10, "Jivko"),
                new Person(11, "Toshko")
            };

            this.database = new ExtendedDatabase(persons);
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            var expectedResult = 11;
            var actualResult = this.database.Count;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DatabaseAddMethodShouldWorkCorrectly()
        {
            var person = new Person(12, "Paul");

            this.database.Add(person);

            var expectedResult = 12;
            var actualResult = this.database.Count;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfCapacityIsOverflown()
        {
            var person1 = new Person(12, "John");
            var person2 = new Person(13, "Paul");
            var person3 = new Person(14, "Green");
            var person4 = new Person(15, "Brown");
            var person5 = new Person(16, "Killer");

            this.database.Add(person1);
            this.database.Add(person2);
            this.database.Add(person3);
            this.database.Add(person4);
            this.database.Add(person5);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Destroyer")));
        }

        [Test]
        public void DatabaseShouldThrowExceptionIfPersonWithSameUsernameIsAdded()
        {
            var person = new Person(12, "Pesho");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void DatabaseShouldThrowExceptionIfPersonWithSameIdIsAdded()
        {
            var person = new Person(1, "John");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void DatabaseRemoveMethodShouldWorkCorrectly()
        {
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(10));
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldWorkCorrectly()
        {
            var expectedResult = "Pesho";
            var actualResult = this.database.FindByUsername("Pesho").UserName;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldBeCaseSensitive()
        {
            var notExpectedResult = "peShO";
            var actualResult = this.database.FindByUsername("Pesho").UserName;

            Assert.That(actualResult, Is.Not.EqualTo(notExpectedResult));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameIsNull(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username));
        }

        [Test]
        [TestCase("Kiro")]
        [TestCase("Paul")]
        public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameIsNotFound(string username)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void DatabaseFindByIdMethodShouldWorkCorrectly()
        {
            var expectedResult = "Gosho";
            var actualResult = this.database.FindById(2).UserName;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(25));
        }
    }
}