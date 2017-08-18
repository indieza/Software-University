namespace Tests.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AxeTest
    {
        private Axe axe;
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;

        private Dummy dummy;
        private const int DummyHealth = 10;
        private const int DummyExerience = 10;

        [Test]
        public void TestMethod()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExerience);

            this.axe.Attack(this.dummy);

            Assert.AreEqual(9, this.axe.DurabilityPoints);
        }
    }
}