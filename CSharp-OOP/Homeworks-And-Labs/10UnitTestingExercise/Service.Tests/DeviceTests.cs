namespace Service.Tests
{
    using System;

    using Service.Models.Devices;
    using Service.Models.Parts;

    using NUnit.Framework;

    public class DeviceTests
    {
        [Test]
        public void LaptopShouldBeCreatedSuccessfully()
        {
            var device = new Laptop("DELL");

            var expectedMake = "DELL";

            Assert.AreEqual(expectedMake, device.Make);
            Assert.IsNotNull(device);
        }

        [Test]
        public void PcShouldBeCreatedSuccessfully()
        {
            var device = new PC("Acer");

            var expectedMake = "Acer";

            Assert.AreEqual(expectedMake, device.Make);
            Assert.IsNotNull(device);
        }

        [Test]
        public void PhoneShouldBeCreatedSuccessfully()
        {
            var device = new Phone("iPhone");

            var expectedMake = "iPhone";

            Assert.AreEqual(expectedMake, device.Make);
            Assert.IsNotNull(device);
        }

        [Test]
        public void LaptopMakeShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Laptop(null));
        }

        [Test]
        public void LaptopMakeShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Laptop(""));
        }

        [Test]
        public void PcMakeShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new PC(null));
        }

        [Test]
        public void PcMakeShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new PC(""));
        }

        [Test]
        public void PhoneMakeShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null));
        }

        [Test]
        public void PhoneMakeShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone(""));
        }

        [Test]
        public void LaptopAddPartShouldThrowExceptionIfPartIsWrong()
        {
            var laptop = new Laptop("Dell");

            var pcPart = new PCPart("PcPart", 3.50m);
            var phonePart = new PhonePart("PhonePart", 2.50m);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(pcPart));
            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(phonePart));
        }

        [Test]
        public void LaptopAddPartShouldThrowExceptionIfPartIsAlreadyExisting()
        {
            var laptop = new Laptop("Dell");

            var laptopPart = new LaptopPart("LaptopPart", 3.50m);

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(laptopPart));
        }

        [Test]
        public void LaptopAddPartShouldWorksCorrectly()
        {
            var laptop = new Laptop("Dell");

            var laptopPart1 = new LaptopPart("LaptopPart1", 3.50m);
            var laptopPart2 = new LaptopPart("LaptopPart2", 3.50m);

            laptop.AddPart(laptopPart1);
            laptop.AddPart(laptopPart2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, laptop.Parts.Count);
        }

        [Test]
        public void PcAddPartShouldThrowExceptionIfPartIsWrong()
        {
            var pc = new PC("Acer");

            var laptopPart = new LaptopPart("LaptopPart", 3.50m);
            var phonePart = new PhonePart("PhonePart", 2.50m);

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(laptopPart));
            Assert.Throws<InvalidOperationException>(() => pc.AddPart(phonePart));
        }

        [Test]
        public void PcAddPartShouldThrowExceptionIfPartIsAlreadyExisting()
        {
            var pc = new PC("Dell");

            var pcPart = new PCPart("PcPart", 3.50m);

            pc.AddPart(pcPart);

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(pcPart));
        }

        [Test]
        public void PcAddPartShouldWorksCorrectly()
        {
            var pc = new PC("Dell");

            var pcPart1 = new PCPart("PcPart1", 3.50m);
            var pcPart2 = new PCPart("PcPart2", 3.50m);

            pc.AddPart(pcPart1);
            pc.AddPart(pcPart2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, pc.Parts.Count);
        }

        [Test]
        public void PhoneAddPartShouldThrowExceptionIfPartIsWrong()
        {
            var phone = new Phone("iPhone");

            var laptopPart = new LaptopPart("LaptopPart", 3.50m);
            var pcPart = new PCPart("PcPart", 2.50m);

            Assert.Throws<InvalidOperationException>(() => phone.AddPart(laptopPart));
            Assert.Throws<InvalidOperationException>(() => phone.AddPart(pcPart));
        }

        [Test]
        public void PhoneAddPartShouldThrowExceptionIfPartIsAlreadyExisting()
        {
            var phone = new Phone("iPhone");

            var phonePart = new PhonePart("PhonePart", 3.50m);

            phone.AddPart(phonePart);

            Assert.Throws<InvalidOperationException>(() => phone.AddPart(phonePart));
        }

        [Test]
        public void PhoneAddPartShouldWorksCorrectly()
        {
            var phone = new Phone("iPhone");

            var phonePart1 = new PhonePart("PhonePart1", 3.50m);
            var phonePart2 = new PhonePart("PhonePart2", 3.50m);

            phone.AddPart(phonePart1);
            phone.AddPart(phonePart2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, phone.Parts.Count);
        }

        [Test]
        public void LaptopRemovePartNameCannotBeNull()
        {
            var laptop = new Laptop("Dell");

            Assert.Throws<ArgumentException>(() => laptop.RemovePart(null));
        }

        [Test]
        public void LaptopRemovePartNameCannotBeEmpty()
        {
            var laptop = new Laptop("Dell");

            Assert.Throws<ArgumentException>(() => laptop.RemovePart(""));
        }

        [Test]
        public void LaptopRemovePartMethodCannotRemoveNonExistingPart()
        {
            var laptop = new Laptop("Dell");

            var part = new LaptopPart("LaptopPart", 5.50m);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("PcPart"));
        }

        [Test]
        public void LaptopRemovePartMethodShouldWorkCorrectly()
        {
            var laptop = new Laptop("Dell");
            var part1 = new LaptopPart("LaptopPart1", 7.50m);
            var part2 = new LaptopPart("LaptopPart2", 3.50m);

            laptop.AddPart(part1);
            laptop.AddPart(part2);
            laptop.RemovePart(part1.Name);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, laptop.Parts.Count);
        }

        [Test]
        public void PcRemovePartNameCannotBeNull()
        {
            var pc = new PC("Dell");

            Assert.Throws<ArgumentException>(() => pc.RemovePart(null));
        }

        [Test]
        public void PcRemovePartNameCannotBeEmpty()
        {
            var pc = new PC("Dell");

            Assert.Throws<ArgumentException>(() => pc.RemovePart(""));
        }

        [Test]
        public void PcRemovePartMethodCannotRemoveNonExistingPart()
        {
            var pc = new PC("Dell");

            var part = new PCPart("PcPart", 5.50m);

            pc.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => pc.RemovePart("LaptopPart"));
        }

        [Test]
        public void PcRemovePartMethodShouldWorkCorrectly()
        {
            var pc = new PC("Dell");
            var part1 = new PCPart("PcPart1", 7.50m);
            var part2 = new PCPart("PcPart2", 3.50m);

            pc.AddPart(part1);
            pc.AddPart(part2);
            pc.RemovePart(part1.Name);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, pc.Parts.Count);
        }

        [Test]
        public void PhoneRemovePartNameCannotBeNull()
        {
            var phone = new Phone("iPhone");

            Assert.Throws<ArgumentException>(() => phone.RemovePart(null));
        }

        [Test]
        public void PhoneRemovePartNameCannotBeEmpty()
        {
            var phone = new Phone("iPhone");

            Assert.Throws<ArgumentException>(() => phone.RemovePart(""));
        }

        [Test]
        public void PhoneRemovePartMethodCannotRemoveNonExistingPart()
        {
            var phone = new Phone("iPhone");

            var part = new PhonePart("PhonePart", 5.50m);

            phone.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => phone.RemovePart("LaptopPart"));
        }

        [Test]
        public void PhoneRemovePartMethodShouldWorkCorrectly()
        {
            var phone = new Phone("iPhone");
            var part1 = new PhonePart("PhonePart1", 7.50m);
            var part2 = new PhonePart("PhonePart2", 3.50m);

            phone.AddPart(part1);
            phone.AddPart(part2);
            phone.RemovePart(part1.Name);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, phone.Parts.Count);
        }

        [Test]
        public void LaptopRepairPartNameCannotBeNull()
        {
            var laptop = new Laptop("Dell");

            Assert.Throws<ArgumentException>(() => laptop.RepairPart(null));
        }

        [Test]
        public void LaptopRepairPartNameCannotBeEmpty()
        {
            var laptop = new Laptop("Dell");

            Assert.Throws<ArgumentException>(() => laptop.RepairPart(""));
        }

        [Test]
        public void LaptopRepairPartMethodCannotRepairNonExistingPart()
        {
            var laptop = new Laptop("Dell");

            var part = new LaptopPart("LaptopPart", 5.50m);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart("PcPart"));
        }

        [Test]
        public void LaptopRepairPartMethodCannotRepairNonBrokenPart()
        {
            var laptop = new Laptop("Dell");
            var part = new LaptopPart("LaptopPart", 5.50m, false);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart("LaptopPart"));
        }

        [Test]
        public void LaptopRepairPartMethodShouldWorksCorrectly()
        {
            var laptop = new Laptop("Dell");
            var part = new LaptopPart("LaptopPart", 5.50m, true);

            laptop.AddPart(part);
            laptop.RepairPart(part.Name);

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void PcRepairPartNameCannotBeNull()
        {
            var pc = new PC("Dell");

            Assert.Throws<ArgumentException>(() => pc.RepairPart(null));
        }

        [Test]
        public void PcRepairPartNameCannotBeEmpty()
        {
            var pc = new PC("Dell");

            Assert.Throws<ArgumentException>(() => pc.RepairPart(""));
        }

        [Test]
        public void PcRepairPartMethodCannotRepairNonExistingPart()
        {
            var pc = new PC("Dell");

            var part = new PCPart("LaptopPart", 5.50m);

            pc.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => pc.RepairPart("PcPart"));
        }

        [Test]
        public void PcRepairPartMethodCannotRepairNonBrokenPart()
        {
            var pc = new PC("Dell");
            var part = new PCPart("LaptopPart", 5.50m, false);

            pc.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => pc.RepairPart("LaptopPart"));
        }

        [Test]
        public void PcRepairPartMethodShouldWorksCorrectly()
        {
            var pc = new PC("Dell");
            var part = new PCPart("PcPart", 3.25m, true);

            pc.AddPart(part);
            pc.RepairPart(part.Name);

            Assert.IsFalse(part.IsBroken);
        }

        [Test]
        public void PhoneRepairPartNameCannotBeNull()
        {
            var phone = new Phone("iPhone");

            Assert.Throws<ArgumentException>(() => phone.RepairPart(null));
        }

        [Test]
        public void PhoneRepairPartNameCannotBeEmpty()
        {
            var phone = new Phone("iPhone");

            Assert.Throws<ArgumentException>(() => phone.RepairPart(""));
        }

        [Test]
        public void PhoneRepairPartMethodCannotRepairNonExistingPart()
        {
            var phone = new Phone("iPhone");
            var part = new PhonePart("PhonePart", 5.50m);

            phone.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => phone.RepairPart("PcPart"));
        }

        [Test]
        public void PhoneRepairPartMethodCannotRepairNonBrokenPart()
        {
            var phone = new Phone("iPhone");
            var part = new PhonePart("PhonePart", 5.50m, false);

            phone.AddPart(part);

            Assert.Throws<InvalidOperationException>(() => phone.RepairPart("PhonePart"));
        }

        [Test]
        public void PhoneRepairPartMethodShouldWorksCorrectly()
        {
            var phone = new Phone("iPhone");
            var part = new PhonePart("PhonePart", 12.75m, true);

            phone.AddPart(part);
            phone.RepairPart(part.Name);

            Assert.IsFalse(part.IsBroken);
        }
    }
}
