namespace _02.Blobs.Entities.Behaviors
{
    public class Aggressive : Behavior
    {
        private static int AggressiveDamageMultiplier = 2;
        private static int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        private void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
        }

        public override void Trigger(Blob source)
        {
            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyRecurrentEffect(Blob source)
        {
            if (this.ToDelayRecurrentEffect)
            {
               this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Damage -= AggressiveDamageDecrementer;

                if (source.Damage <= this.sourceInitialDamage)
                {
                    source.Damage = this.sourceInitialDamage;
                }
            }
        }
    }
}