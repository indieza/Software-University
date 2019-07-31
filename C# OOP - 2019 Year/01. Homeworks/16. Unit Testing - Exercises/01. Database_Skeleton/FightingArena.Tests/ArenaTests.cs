using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual(0, this.arena.Warriors.Count);
        }

        [Test]
        public void Test_Enroll_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name1", 10, 10);

            this.arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior2));
        }

        [Test]
        public void Test_Enroll()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 10);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);
            Assert.AreEqual(2, this.arena.Count);
        }
    }
}