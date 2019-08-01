using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Name");

            Person[] people = new Person[16];

            for (int i = 0; i <= 15; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Assert.AreEqual(1, this.person.Id);
            Assert.AreEqual("Name", this.person.UserName);
        }

        [Test]
        public void Test_DatabaseCount()
        {
            Assert.AreEqual(16, this.database.Count);
        }

        [Test]
        public void Test_Add_Range_Exception()
        {
            Person[] people = new Person[17];
            Assert
                .Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_First_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(this.person));
        }

        [Test]
        public void Test_Add_Second_Exception()
        {
            this.database.Remove();
            Person targetPerson = new Person(102, "Name1");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(targetPerson));
        }

        [Test]
        public void Test_Add_Third_Exception()
        {
            this.database.Remove();
            Person targetPerson = new Person(0, "Name102");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(targetPerson));
        }

        [Test]
        public void Test_Add_Method()
        {
            this.database.Remove();
            this.database.Remove();
            Person targetPerson = new Person(23, "Name102");
            this.database.Add(targetPerson);
            Assert.AreEqual(15, this.database.Count);
        }

        [Test]
        public void Test_Remove_Exception()
        {
            int count = this.database.Count;

            for (int i = 0; i < count; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Test_Remove_Method()
        {
            int count = this.database.Count - 2;

            for (int i = 0; i < count; i++)
            {
                this.database.Remove();
            }

            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void Test_Find_By_Username_First_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void Test_Find_By_Username_Second_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Pesho300"));
        }

        [Test]
        public void Test_Find_By_Username()
        {
            Assert.AreEqual(1, this.database.FindByUsername("Name1").Id);
            Assert.AreEqual("Name1", this.database.FindByUsername("Name1").UserName);
        }

        [Test]
        public void Test_Find_By_Id_First_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void Test_Find_By_Id_Second_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(35));
        }

        [Test]
        public void Test_Find_By_Id()
        {
            Assert.AreEqual(2, this.database.FindById(2).Id);
            Assert.AreEqual("Name2", this.database.FindById(2).UserName);
        }
    }
}