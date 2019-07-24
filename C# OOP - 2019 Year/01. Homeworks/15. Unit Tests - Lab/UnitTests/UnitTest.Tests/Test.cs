using NUnit.Framework;
using UnitTests;

namespace UnitTest.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestConstructure()
        {
            Person person = new Person("Simeon", "Valev", 19);

            Assert.AreEqual("Simeon", person.FirstName);
            Assert.AreEqual("Valev", person.LastName);
            Assert.AreEqual(19, person.Age);
        }

        [Test]
        public void TestFirstNameLength()
        {
            Person person = new Person("Sim", "Valev", 19);

            Assert.That(() => person.TestFirstName(),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Name should have at least 4 symbols length"));
        }
    }
}