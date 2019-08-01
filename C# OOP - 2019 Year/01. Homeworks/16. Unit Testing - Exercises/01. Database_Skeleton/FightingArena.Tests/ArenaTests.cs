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
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_Enroll_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name1", 10, 10);

            this.arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior2));
            Assert.AreEqual(1, this.arena.Count);
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

        [Test]
        public void Test_Fight_Player_One_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 10);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Name3", "Name2"));
        }

        [Test]
        public void Test_Fight_Player_Two_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 10);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Name1", "Name3"));
        }

        [Test]
        public void Test_Fight_Method()
        {
            Warrior warrior1 = new Warrior("Name1", 5, 100);
            Warrior warrior2 = new Warrior("Name2", 10, 50);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            this.arena.Fight("Name1", "Name2");

            Assert.AreEqual(90, warrior1.HP);
            Assert.AreEqual(45, warrior2.HP);
        }
    }
}