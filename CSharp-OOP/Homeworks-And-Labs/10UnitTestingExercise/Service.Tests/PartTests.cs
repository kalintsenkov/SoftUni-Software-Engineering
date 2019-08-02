namespace Tests
{
    using System;

    using Service.Models.Parts;

    using NUnit.Framework;

    public class PartTests
    {
        [Test]
        public void LaptopPartShouldBeCreatedSuccessfully()
        {
            var part = new LaptopPart("JustLaptopPart", 5.00M);

            var expectedName = "JustLaptopPart";
            var expectedCost = 7.5M;
            var expectedBrokenBool = false;

            Assert.AreEqual(expectedName, part.Name);
            Assert.AreEqual(expectedCost, part.Cost);
            Assert.AreEqual(expectedBrokenBool, part.IsBroken);
        }

        [Test]
        public void PcPartShouldBeCreatedSuccessfully()
        {
            var part = new PCPart("JustPcPart", 5.00M, true);

            var expectedName = "JustPcPart";
            var expectedCost = 6.00M;
            var expectedBrokenBool = true;

            Assert.AreEqual(expectedName, part.Name);
            Assert.AreEqual(expectedCost, part.Cost);
            Assert.AreEqual(expectedBrokenBool, part.IsBroken);
        }

        [Test]
        public void PhonePartShouldBeCreatedSuccessfully()
        {
            var part = new PhonePart("JustPhonePart", 5.00M);

            var expectedName = "JustPhonePart";
            var expectedCost = 6.5M;
            var expectedBrokenBool = false;

            Assert.AreEqual(expectedName, part.Name);
            Assert.AreEqual(expectedCost, part.Cost);
            Assert.AreEqual(expectedBrokenBool, part.IsBroken);
        }

        [Test]
        public void LaptopPartNameShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(null, 5.00M));
        }

        [Test]
        public void LaptopPartNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart("", 5.00M));
        }

        [Test]
        public void LaptopPartCostShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart("JustLaptopPart", -5.00M));
        }

        [Test]
        public void LaptopPartCostShouldThrowExceptionIfIsZero()
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart("JustLaptopPart", 0));
        }

        [Test]
        public void PcPartNameShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new PCPart(null, 5.00M));
        }

        [Test]
        public void PcPartNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new PCPart("", 5.00M));
        }

        [Test]
        public void PcPartCostShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new PCPart("JustLaptopPart", -5.00M));
        }

        [Test]
        public void PcPartCostShouldThrowExceptionIfIsZero()
        {
            Assert.Throws<ArgumentException>(() => new PCPart("JustLaptopPart", 0));
        }

        [Test]
        public void PhonePartNameShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart(null, 5.00M));
        }

        [Test]
        public void PhonePartNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart("", 5.00M));
        }

        [Test]
        public void PhonePartCostShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart("JustLaptopPart", -5.00M));
        }

        [Test]
        public void PhonePartCostShouldThrowExceptionIfIsZero()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart("JustLaptopPart", 0));
        }

        [Test]
        public void LaptopPartRepairShouldWorksCorrectly()
        {
            var part = new LaptopPart("JustLaptopPart", 2.50M, true);

            part.Repair();

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void PcPartRepairShouldWorksCorrectly()
        {
            var part = new PCPart("JustLaptopPart", 2.50M, true);

            part.Repair();

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void PhonePartRepairShouldWorksCorrectly()
        {
            var part = new PhonePart("JustLaptopPart", 2.50M, true);

            part.Repair();

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void LaptopPartReportShouldGiveCorrectInfo()
        {
            var part = new LaptopPart("JustLaptopPart", 2.50M, true);

            var expectedReport = $"JustLaptopPart - 3.75$" + Environment.NewLine +
                $"Broken: True";

            Assert.AreEqual(expectedReport, part.Report());
        }

        [Test]
        public void PcPartReportShouldGiveCorrectInfo()
        {
            var part = new PCPart("JustLaptopPart", 3.50M, false);

            var expectedReport = $"JustLaptopPart - 4.20$" + Environment.NewLine +
                $"Broken: False";

            Assert.AreEqual(expectedReport, part.Report());
        }

        [Test]
        public void PhonePartReportShouldGiveCorrectInfo()
        {
            var part = new PhonePart("JustLaptopPart", 5.50M, true);

            var expectedReport = $"JustLaptopPart - 7.15$" + Environment.NewLine +
                $"Broken: True";

            Assert.AreEqual(expectedReport, part.Report());
        }
    }
}