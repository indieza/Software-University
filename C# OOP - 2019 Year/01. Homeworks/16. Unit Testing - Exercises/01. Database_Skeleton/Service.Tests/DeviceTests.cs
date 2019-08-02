using NUnit.Framework;
using Service.Models.Devices;
using System;

namespace Service.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        private Laptop laptop;
        private PC pc;
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.laptop = new Laptop("LaptopMake");
            this.pc = new PC("PCMake");
            this.phone = new Phone("PhoneMake");
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual("LaptopMake", this.laptop.Make);
            Assert.AreEqual("PCMake", this.pc.Make);
            Assert.AreEqual("PhoneMake", this.phone.Make);
            Assert.NotNull(this.phone.Parts);
            Assert.NotNull(this.pc.Parts);
            Assert.NotNull(this.laptop.Parts);
        }

        [Test]
        public void Test_Make_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null));
        }
    }
}