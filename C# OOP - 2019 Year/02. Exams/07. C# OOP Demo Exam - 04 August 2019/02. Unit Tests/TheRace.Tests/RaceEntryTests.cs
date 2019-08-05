using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitMotorcycle unitMotorcycle1;
        private UnitMotorcycle unitMotorcycle2;
        private UnitMotorcycle unitMotorcycle3;
        private UnitRider unitRider1;
        private UnitRider unitRider2;
        private UnitRider unitRider3;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitMotorcycle1 = new UnitMotorcycle("Model1", 10, 10);
            this.unitMotorcycle2 = new UnitMotorcycle("Model2", 20, 20);
            this.unitMotorcycle3 = new UnitMotorcycle("Model3", 30, 30);
            this.unitRider1 = new UnitRider("Name1", this.unitMotorcycle1);
            this.unitRider2 = new UnitRider("Name2", this.unitMotorcycle2);
            this.unitRider3 = new UnitRider("Name3", this.unitMotorcycle3);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void Test_Constructures()
        {
            Assert.AreEqual("Model1", this.unitMotorcycle1.Model);
            Assert.AreEqual(10, this.unitMotorcycle1.HorsePower);
            Assert.AreEqual(10, this.unitMotorcycle1.CubicCentimeters);

            Assert.AreEqual("Name1", this.unitRider1.Name);
            Assert.AreEqual(this.unitMotorcycle1, this.unitRider1.Motorcycle);

            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void Test_Name_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, this.unitMotorcycle1));
        }

        [Test]
        public void Test_Add_Null_Rider_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void Test_Add_Existing_Rider_Exception()
        {
            this.raceEntry.AddRider(this.unitRider1);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(this.unitRider1));
        }

        [Test]
        public void Test_Add_Rider()
        {
            Assert.AreEqual("Rider Name1 added in race.", this.raceEntry.AddRider(this.unitRider1));
            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void Test_Calculate_Average_Exception()
        {
            this.raceEntry.AddRider(this.unitRider1);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_Calculate_Average()
        {
            this.raceEntry.AddRider(this.unitRider1);
            this.raceEntry.AddRider(this.unitRider2);
            this.raceEntry.AddRider(this.unitRider3);
            Assert.AreEqual(20, this.raceEntry.CalculateAverageHorsePower());
            Assert.AreEqual(3, this.raceEntry.Counter);
        }
    }
}