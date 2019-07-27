namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_Constructure()
        {
            Phone phone = new Phone("Make", "Model");

            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void Test_Make_Property()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "Model"));
        }

        [Test]
        public void Test_Model_Property()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", null));
        }

        [Test]
        public void Test_Add_Contact_Exception()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name", "123");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Name", "123"));
        }

        [Test]
        public void Test_Add_Contact()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name", "123");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void Test_Call_Exception()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name", "123");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Name1"));
        }

        [Test]
        public void Test_Call()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name", "123");

            Assert.AreEqual("Calling Name - 123...", phone.Call("Name"));
        }
    }
}