using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Hero hero;
        private Axe axe;

        [SetUp]
        public void Setup()
        {
            this.hero = new Hero("Name");
            this.axe = new Axe(10, 10);
        }

        [Test]
        public void Test_Hero_Constructure()
        {
            Assert.AreEqual("Name", this.hero.Name);
            Assert.AreEqual(0, this.hero.Experience);
        }

        [Test]
        public void Test_Axe_Constructure()
        {
            Assert.AreEqual(10, this.axe.AttackPoints);
            Assert.AreEqual(10, this.axe.DurabilityPoints);
        }
    }
}