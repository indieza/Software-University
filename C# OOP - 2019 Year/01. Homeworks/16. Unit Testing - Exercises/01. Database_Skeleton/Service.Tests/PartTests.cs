using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    [TestFixture]
    public class PartTests
    {
        private LaptopPart laptopPart1;
        private LaptopPart laptopPart2;
        private PCPart pCPart1;
        private PCPart pCPart2;
        private PhonePart phonePart1;
        private PhonePart phonePart2;

        [SetUp]
        public void Setup()
        {
            this.laptopPart1 = new LaptopPart("LaptopPartName1", 10);
            this.laptopPart2 = new LaptopPart("LaptopPartName2", 20, true);

            this.pCPart1 = new PCPart("PCPartName1", 10);
            this.pCPart2 = new PCPart("PCPartName2", 20, true);

            this.phonePart1 = new PhonePart("PhonePartName1", 10);
            this.phonePart2 = new PhonePart("PhonePartName2", 20, true);
        }

        [Test]
        public void Test_First_Constructure()
        {
            Assert.AreEqual("LaptopPartName1", this.laptopPart1.Name);
            Assert.AreEqual(15, this.laptopPart1.Cost);
            Assert.AreEqual(false, this.laptopPart1.IsBroken);

            Assert.AreEqual("PCPartName1", this.pCPart1.Name);
            Assert.AreEqual(12, this.pCPart1.Cost);
            Assert.AreEqual(false, this.pCPart1.IsBroken);

            Assert.AreEqual("PhonePartName1", this.phonePart1.Name);
            Assert.AreEqual(13, this.phonePart1.Cost);
            Assert.AreEqual(false, this.phonePart1.IsBroken);
        }

        [Test]
        public void Test_Second_Constructure()
        {
            Assert.AreEqual("LaptopPartName2", this.laptopPart2.Name);
            Assert.AreEqual(30, this.laptopPart2.Cost);
            Assert.AreEqual(true, this.laptopPart2.IsBroken);

            Assert.AreEqual("PCPartName2", this.pCPart2.Name);
            Assert.AreEqual(24, this.pCPart2.Cost);
            Assert.AreEqual(true, this.pCPart2.IsBroken);

            Assert.AreEqual("PhonePartName2", this.phonePart2.Name);
            Assert.AreEqual(26, this.phonePart2.Cost);
            Assert.AreEqual(true, this.phonePart2.IsBroken);
        }

        [Test]
        public void Test_Name_Exception()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart(null, 10));
        }

        [Test]
        public void Test_Cost_Exception()
        {
            Assert.Throws<ArgumentException>(() => new PhonePart("Name", 0));
        }

        [Test]
        public void Test_Repair()
        {
            this.laptopPart2.Repair();
            Assert.AreEqual(false, this.laptopPart2.IsBroken);
        }

        [Test]
        public void Test_Report()
        {
            Assert.AreEqual($"LaptopPartName1 - 15.00$" + Environment.NewLine + $"Broken: False",
                this.laptopPart1.Report());
        }
    }
}