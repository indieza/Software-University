namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone1;

        [SetUp]
        public void Set_Up()
        {
            this.phone1 = new Phone("Make1", "Model1");
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual("Make1", this.phone1.Make);
            Assert.AreEqual("Model1", this.phone1.Model);
            Assert.AreEqual(0, this.phone1.Count);
        }

        [Test]
        public void Test_Make()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "Model"));
        }

        [Test]
        public void Test_Model()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", null));
        }

        [Test]
        public void Test_Add_Contact()
        {
            this.phone1.AddContact("Name1", "Phone1");
            this.phone1.AddContact("Name2", "Phone2");

            Assert.AreEqual(2, this.phone1.Count);
        }

        [Test]
        public void Test_Add_Contact_Exception()
        {
            this.phone1.AddContact("Name1", "Phone1");
            this.phone1.AddContact("Name2", "Phone2");

            Assert.Throws<InvalidOperationException>(() => this.phone1.AddContact("Name1", "Phone1"));
            Assert.AreEqual(2, this.phone1.Count);
        }

        [Test]
        public void Test_Call()
        {
            this.phone1.AddContact("Name1", "Phone1");
            this.phone1.AddContact("Name2", "Phone2");

            Assert.AreEqual("Calling Name1 - Phone1...", this.phone1.Call("Name1"));
        }

        [Test]
        public void Test_Call_Exception()
        {
            this.phone1.AddContact("Name1", "Phone1");
            this.phone1.AddContact("Name2", "Phone2");

            Assert.Throws<InvalidOperationException>(() => this.phone1.Call("Name3"));
        }
    }
}