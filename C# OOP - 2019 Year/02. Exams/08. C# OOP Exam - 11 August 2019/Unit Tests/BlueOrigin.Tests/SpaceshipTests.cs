namespace BlueOrigin.Tests
{
    using NUnit.Framework;
    using System;

    public class SpaceshipTests
    {
        private Astronaut astronaut1;
        private Astronaut astronaut2;
        private Astronaut astronaut3;
        private Astronaut astronaut4;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.astronaut1 = new Astronaut("Name1", 10);
            this.astronaut2 = new Astronaut("Name2", 20);
            this.astronaut3 = new Astronaut("Name3", 30);
            this.astronaut4 = new Astronaut("Name4", 40);
            this.spaceship = new Spaceship("Ship1", 3);
        }

        [Test]
        public void Test_Constructures()
        {
            Assert.AreEqual("Name1", this.astronaut1.Name);
            Assert.AreEqual(10, this.astronaut1.OxygenInPercentage);

            Assert.AreEqual("Ship1", this.spaceship.Name);
            Assert.AreEqual(3, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void Test_Spaceship_Name_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
        }

        [Test]
        public void Test_Spaceship_Capacity_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Name1", -1));
        }

        [Test]
        public void Test_Full_Ship_Exception()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);
            this.spaceship.Add(this.astronaut3);
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut4));
        }

        [Test]
        public void Test_Add_Existing_Astronaut_Exception()
        {
            this.spaceship.Add(this.astronaut1);
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut1));
        }

        [Test]
        public void Test_Add()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);
            Assert.AreEqual(2, this.spaceship.Count);
        }

        [Test]
        public void Test_Remove_True()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);
            Assert.AreEqual(true, this.spaceship.Remove("Name1"));
        }

        [Test]
        public void Test_Remove_False()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);
            Assert.AreEqual(false, this.spaceship.Remove("Name4"));
        }
    }
}