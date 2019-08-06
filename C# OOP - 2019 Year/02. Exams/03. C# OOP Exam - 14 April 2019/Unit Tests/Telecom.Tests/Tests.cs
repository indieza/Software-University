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
            Assert.AreEqual("Make", this.phone.Make);
            Assert.AreEqual("Model", this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
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
        public void Test_Add_Contact_Exception()
        {
            this.phone.AddContact("Name", "Phone");
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Name", "Phone"));
        }

        [Test]
        public void Test_Add_Contact()
        {
            this.phone.AddContact("Name", "Phone");
            this.phone.AddContact("Name1", "Phone1");

            Assert.AreEqual(2, this.phone.Count);
        }

        [Test]
        public void Test_Call_Exception()
        {
            this.phone.AddContact("Name", "Phone");
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Name1"));
        }

        [Test]
        public void Test_Call()
        {
            this.phone.AddContact("Name", "Phone");
            this.phone.AddContact("Name1", "Phone1");
            Assert.AreEqual("Calling Name - Phone...", this.phone.Call("Name"));
        }
    }
}