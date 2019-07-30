using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Name");
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Assert.AreEqual(1, this.person.Id);
            Assert.AreEqual("Name", this.person.UserName);
        }
    }
}