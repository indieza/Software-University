using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Name", 10, 10);
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual("Name", this.warrior.Name);
            Assert.AreEqual(10, this.warrior.Damage);
            Assert.AreEqual(10, this.warrior.HP);
        }

        [Test]
        public void Test_Name()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 10));
        }

        [Test]
        public void Test_Damage()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 0, 10));
        }

        [Test]
        public void Test_HP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 10, -10));
        }

        [Test]
        public void Test_Attack_First_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 40);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Second_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 10, 30);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Third_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 50, 50);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_This_HP()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior1.HP);
        }

        [Test]
        public void Test_Attack_If_Statment()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void Test_Attack_Else_Statment()
        {
            Warrior warrior1 = new Warrior("Name1", 39, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior2.HP);
        }
    }
}