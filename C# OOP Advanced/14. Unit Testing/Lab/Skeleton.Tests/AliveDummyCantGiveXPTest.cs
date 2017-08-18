namespace Tests.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AliveDummyCantGiveXPTest
    {
        private Dummy dummy;
        private const int DummyHealth = 10;
        private const int DummyExerience = 10;

        [Test]
        public void IsAliveDummyCantGiveXP()
        {
            this.dummy = new Dummy(DummyHealth, DummyExerience);
            this.dummy.Experience += this.dummy.GiveExperience();

            Assert.AreEqual(20, this.dummy.Experience);
        }
    }
}