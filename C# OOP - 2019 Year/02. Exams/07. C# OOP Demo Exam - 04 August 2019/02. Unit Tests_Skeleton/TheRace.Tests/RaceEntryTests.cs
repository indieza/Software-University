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
        public void Test_Constructor()
        {
            Assert.AreEqual("Model1", this.unitMotorcycle1.Model);
            Assert.AreEqual(10, this.unitMotorcycle1.HorsePower);
            Assert.AreEqual(10, this.unitMotorcycle1.CubicCentimeters);

            Assert.AreEqual("Name1", this.unitRider1.Name);
            Assert.AreEqual(this.unitMotorcycle1, this.unitRider1.Motorcycle);

            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void Test_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, this.unitMotorcycle2));
        }

        [Test]
        public void Add_Null_Rider()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void Add_Existing_Rider()
        {
            this.raceEntry.AddRider(this.unitRider2);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(this.unitRider2));
        }

        [Test]
        public void Add_Rider()
        {
            Assert.AreEqual("Rider Name2 added in race.", this.raceEntry.AddRider(this.unitRider2));

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void Add_Calculate_Not_Enought_Riders()
        {
            this.raceEntry.AddRider(this.unitRider2);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Add_Calculate_Average()
        {
            this.raceEntry.AddRider(this.unitRider1);
            this.raceEntry.AddRider(this.unitRider2);
            this.raceEntry.AddRider(this.unitRider3);

            Assert.AreEqual(20, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}