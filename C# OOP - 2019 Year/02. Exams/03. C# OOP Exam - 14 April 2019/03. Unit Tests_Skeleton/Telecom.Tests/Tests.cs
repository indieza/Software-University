namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestConstucture()
        {
            Phone phone = new Phone("Make", "Model");

            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void TestMakeProperty()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "Model"));
        }

        [Test]
        public void TestModelProperty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", null));
        }

        [Test]
        public void TestAddContactMethod()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name1", "Phone1");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void TestAddContactMethodException()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name1", "Phone1");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Name1", "Phone1"));
        }

        [Test]
        public void TestCallMethod()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name1", "Phone1");

            Assert.AreEqual("Calling Name1 - Phone1...", phone.Call("Name1"));
        }

        [Test]
        public void TestCallMethodException()
        {
            Phone phone = new Phone("Make", "Model");

            phone.AddContact("Name1", "Phone1");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Name2"));
        }
    }
}