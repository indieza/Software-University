namespace Tests.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class IsDeadDummyCanGiveXPTest
    {
        private Dummy dummy;
        private const int DummyHealth = 10;
        private const int DummyExerience = 10;
        private const int AttackPoints = 20;

        [Test]
        public void IsDeadDummyCanGiveXP()
        {
            this.dummy = new Dummy(DummyHealth, DummyExerience);
            this.dummy.TakeAttack(AttackPoints);

            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        }
    }
}