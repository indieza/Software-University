using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            this.database = new Database.Database(nums);
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void Test_Add_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Test_Add()
        {
            this.database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            this.database.Add(11);
            Assert.AreEqual(11, this.database.Count);
        }

        [Test]
        public void Test_Remove_Element_From_Empty_Collection()
        {
            this.database = new Database.Database();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Test_Remove()
        {
            this.database.Remove();
            Assert.AreEqual(15, this.database.Count);
        }

        [Test]
        public void Test_Fetch()
        {
            Assert.AreEqual(16, this.database.Fetch().Length);
        }
    }
}