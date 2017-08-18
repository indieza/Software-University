namespace Tests.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    internal class DummyIsDeath
    {
        private Dummy dummy;
        private const int DummyHealth = -1;
        private const int DummyExerience = 10;

        [Test]
        public void TestIsDummyDeath()
        {
            this.dummy = new Dummy(DummyHealth, DummyExerience);
            this.dummy.GiveExperience();

            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        }
    }
}