namespace Tests.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyLoseHealthTest
    {
        private Dummy dummy;
        private const int DummyHealth = 10;
        private const int DummyExerience = 10;
        private const int AttackPoints = 5;

        [Test]
        public void TestDummyLosesHealth()
        {
            this.dummy = new Dummy(DummyHealth, DummyExerience);
            this.dummy.TakeAttack(AttackPoints);

            Assert.AreEqual(5, this.dummy.Health);
        }
    }
}