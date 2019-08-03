using NUnit.Framework;
using Service.Models.Contracts;
using Service.Models.Devices;
using Service.Models.Parts;
using System;
using System.Linq;

namespace Service.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        private Laptop laptop;
        private PC pc;
        private Phone phone;
        private LaptopPart laptopPart1;
        private LaptopPart laptopPart2;
        private PCPart pcPart;
        private PhonePart phonePart;

        [SetUp]
        public void Setup()
        {
            this.laptop = new Laptop("LaptopMake");
            this.pc = new PC("PCMake");
            this.phone = new Phone("PhoneMake");
            this.laptopPart1 = new LaptopPart("RAM", 10, true);
            this.laptopPart2 = new LaptopPart("HDD", 50, false);
            this.pcPart = new PCPart("SSD", 15);
            this.phonePart = new PhonePart("Camera", 20);
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

        [Test]
        public void Test_Add_Existing_Part_Exception()
        {
            this.laptop.AddPart(this.laptopPart1);
            Assert.Throws<InvalidOperationException>(() => this.laptop.AddPart(this.laptopPart1));
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_Laptop_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.laptop.AddPart(this.pcPart));
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_PC_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.pc.AddPart(this.phonePart));
        }

        [Test]
        public void Test_Add_Not_Correct_Part_For_Phone_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.AddPart(this.laptopPart1));
        }

        [Test]
        public void Test_Add_Part_Correctly()
        {
            this.laptop.AddPart(this.laptopPart1);
            this.laptop.AddPart(this.laptopPart2);
            var parts = this.laptop.Parts;
            Assert.That(parts, Has.Member(this.laptopPart1));
            Assert.That(parts, Has.Member(this.laptopPart2));
            Assert.AreEqual(2, this.laptop.Parts.Count);
        }

        [Test]
        public void Test_Remove_Part_With_Empty_Name()
        {
            this.laptop.AddPart(this.laptopPart1);
            Assert.Throws<ArgumentException>(() => this.laptop.RemovePart(null));
        }

        [Test]
        public void Test_Remove_Not_Existing_Part()
        {
            this.laptop.AddPart(this.laptopPart1);
            Assert.Throws<InvalidOperationException>(() => this.laptop.RemovePart(this.laptopPart2.Name));
        }

        [Test]
        public void Test_Remove_Part()
        {
            this.laptop.AddPart(this.laptopPart1);
            this.laptop.AddPart(this.laptopPart2);
            this.laptop.RemovePart(this.laptopPart2.Name);

            var parts = this.laptop.Parts;

            Assert.That(parts, !Has.Member(this.laptopPart2));
            Assert.AreEqual(1, this.laptop.Parts.Count);
        }

        [Test]
        public void Test_Repair_Part_With_Empty_Name()
        {
            Assert.Throws<ArgumentException>(() => this.laptop.RepairPart(null));
        }

        [Test]
        public void Test_Repair_Not_Existing_Part()
        {
            this.laptop.AddPart(this.laptopPart1);
            Assert.Throws<InvalidOperationException>(() => this.laptop.RepairPart(laptopPart2.Name));
        }

        [Test]
        public void Test_Repair_Not_Broken_Part()
        {
            this.laptop.AddPart(this.laptopPart1);
            this.laptop.AddPart(this.laptopPart2);
            Assert.Throws<InvalidOperationException>(() => this.laptop.RepairPart(laptopPart2.Name));
        }

        [Test]
        public void Test_Repair_Part_Corretct()
        {
            this.laptop.AddPart(this.laptopPart1);
            this.laptop.AddPart(this.laptopPart2);
            this.laptop.RepairPart(this.laptopPart1.Name);

            IPart part = this.laptop.Parts.FirstOrDefault(p => p.Name == this.laptopPart1.Name);

            Assert.AreEqual(false, part.IsBroken);
        }
    }
}