namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Make", "Model");
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void Test_Make_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "Model"));
        }

        [Test]
        public void Test_Model_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", null));
        }

        [Test]
        public void Test_Add_Existing_Contact_Exception()
        {
            this.phone.AddContact("Name", "Phone");
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Name", "Phone"));
        }

        [Test]
        public void Test_Add_Contact()
        {
            this.phone.AddContact("Name1", "Phone1");
            this.phone.AddContact("Name2", "Phone2");
            Assert.AreEqual(2, this.phone.Count);
        }

        [Test]
        public void Test_Call_Not_Existing_Contact_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Name"));
        }

        [Test]
        public void Test_Call()
        {
            this.phone.AddContact("Name1", "Phone1");
            Assert.AreEqual("Calling Name1 - Phone1...", this.phone.Call("Name1"));
        }
    }
}