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
        private UnitRider UnitRider1;
        private UnitRider UnitRider2;
        private UnitRider UnitRider3;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.unitMotorcycle1 = new UnitMotorcycle("Model1", 10, 10);
            this.unitMotorcycle2 = new UnitMotorcycle("Model2", 20, 20);
            this.unitMotorcycle3 = new UnitMotorcycle("Model3", 30, 30);
            this.UnitRider1 = new UnitRider("Name1", this.unitMotorcycle1);
            this.UnitRider2 = new UnitRider("Name2", this.unitMotorcycle2);
            this.UnitRider3 = new UnitRider("Name3", this.unitMotorcycle3);
            this.race = new RaceEntry();
        }

        [Test]
        public void Test_Constructures()
        {
            Assert.AreEqual("Model1", this.unitMotorcycle1.Model);
            Assert.AreEqual(10, this.unitMotorcycle1.HorsePower);
            Assert.AreEqual(10, this.unitMotorcycle1.HorsePower);

            Assert.AreEqual("Name1", this.UnitRider1.Name);
            Assert.AreEqual(this.unitMotorcycle1, this.UnitRider1.Motorcycle);

            Assert.AreEqual(0, this.race.Counter);
        }

        [Test]
        public void Test_Name_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, this.unitMotorcycle1));
        }

        [Test]
        public void Test_Add_Null_Rider()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(null));
        }

        [Test]
        public void Test_Add_Existing_Rider()
        {
            this.race.AddRider(this.UnitRider1);
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(this.UnitRider1));
        }

        [Test]
        public void Test_Add_Rider()
        {
            Assert.AreEqual("Rider Name1 added in race.", this.race.AddRider(this.UnitRider1));
            Assert.AreEqual(1, this.race.Counter);
        }

        [Test]
        public void Test_Calculate_Average_Not_Enought_Riders()
        {
            this.race.AddRider(this.UnitRider1);
            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_Calculate_Average()
        {
            this.race.AddRider(this.UnitRider1);
            this.race.AddRider(this.UnitRider2);
            this.race.AddRider(this.UnitRider3);

            Assert.AreEqual(20, this.race.CalculateAverageHorsePower());
        }
    }
}