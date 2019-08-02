using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person1;
        private Person person2;
        private Person person3;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person1 = new Person(100, "Pesho");
            this.person2 = new Person(101, "Gosho");
            this.person3 = new Person(102, "Shepo");
            this.database = new ExtendedDatabase.ExtendedDatabase(this.person1, this.person2);
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Assert.AreEqual(100, this.person1.Id);
            Assert.AreEqual("Pesho", this.person1.UserName);
        }

        [Test]
        public void Test_Database_Constructure()
        {
            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void Test_Add_Range_Exception()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Assert.Throws<ArgumentException>(() =>
                    this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_Range_Exception_With_Empty_People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
                    this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_Null_People()
        {
            Person[] people = new Person[5];

            Assert.Throws<NullReferenceException>(() =>
                    this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Test_Add_Person_Correctly()
        {
            this.database.Add(person3);

            Assert.AreEqual(3, this.database.Count);
        }

        [Test]
        public void Test_Add_Person_With_Existing_Username()
        {
            Person person = new Person(104, "Pesho");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void Test_Add_Person_With_Existing_Id()
        {
            Person person = new Person(101, "Robot");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void Test_Add_Person_In_Full_Database()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person3));
        }

        [Test]
        public void Test_Remove_Correctly()
        {
            this.database.Remove();

            Assert.AreEqual(1, this.database.Count);
        }

        [Test]
        public void Test_Remove_From_Empty_Database()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Test_Find_By_Null_Username()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    this.database.FindByUsername(null));
        }

        [Test]
        public void Test_Find_By_No_Username()
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.database.FindByUsername(this.person3.UserName));
        }

        [Test]
        public void Test_Find_By_Username()
        {
            Person person = this.database.FindByUsername(person1.UserName);
            Assert.AreEqual(person, this.person1);
        }

        [Test]
        public void Test_By_Negative_Id()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    this.database.FindById(-10));
        }

        [Test]
        public void Test_By_No_Id()
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.database.FindById(102));
        }

        [Test]
        public void Test_By_Id()
        {
            Person person = this.database.FindById(100);

            Assert.AreEqual(person, this.person1);
        }
    }
}