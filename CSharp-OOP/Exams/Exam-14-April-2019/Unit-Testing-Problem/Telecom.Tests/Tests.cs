namespace Telecom.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("iPhone", "XS Max");
        }

        [Test]
        public void PhoneShouldBeCreatedSuccessfully()
        {
            var expectedPhoneMake = "iPhone";
            var expectedPhoneModel = "XS Max";

            Assert.AreEqual(expectedPhoneMake, this.phone.Make);
            Assert.AreEqual(expectedPhoneModel, this.phone.Model);
            Assert.IsNotNull(this.phone);
        }

        [Test]
        public void PhoneMakeShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "8"));
        }

        [Test]
        public void PhoneMakeShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "8"));
        }

        [Test]
        public void PhoneModelShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", null));
        }

        [Test]
        public void PhoneModelShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", ""));
        }

        [Test]
        public void PhoneAddContactMethodShouldWorksCorrectly()
        {
            this.phone.AddContact("Pesho", "08812345");

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void PhoneCannotAddContactWhichIsAlreadyAdded()
        {
            this.phone.AddContact("Pesho", "08812345");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "124124"));
        }

        [Test]
        public void PhoneCountShouldWorksCorrectly()
        {
            this.phone.AddContact("Pesho", "08812345");
            this.phone.AddContact("Gosho", "08855555");
            this.phone.AddContact("Kiro", "088122315");

            var expectedCount = 3;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void PhoneCallMethodShouldWorksCorrectly()
        {
            this.phone.AddContact("Pesho", "08812345");

            var expectedResult = "Calling Pesho - 08812345...";

            Assert.AreEqual(expectedResult, this.phone.Call("Pesho"));
        }

        [Test]
        public void PhoneCallCannotCallNonExistingContact()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Pesho"));
        }
    }
}