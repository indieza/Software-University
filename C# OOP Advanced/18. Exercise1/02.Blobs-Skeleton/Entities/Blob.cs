namespace _02.Blobs.Entities
{
    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Entities.Behaviors;

    public class Blob
    {
        private int health;
        private Attack attack;
        private int triggerCount;

        private int initialHealth;
        private int initialDamage;

        public Blob(string name, int health, int damage, Behavior behavior, Attack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.attack = attack;

            this.initialHealth = health;
            this.initialDamage = damage;
        }

        public string Name { get; private set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2 && !this.Behavior.IsTriggered)
                {
                    this.TriggerBehavior();
                }
            }
        }

        public Behavior Behavior { get; private set; }

        public int Damage { get; set; }

        public void Attack(Blob target)
        {
            if (this.attack is PutridFart)
            {
                this.AttackAffectTarget(this, target);
            }
        }

        public void Respond(int damage)
        {
            this.Health -= damage;
        }

        public void TriggerBehavior()
        {
            if (this.Behavior is Aggressive) {
                if (this.Behavior.IsTriggered)
                {
                    ((Aggressive) this.Behavior).IsTriggered = true;
                    this.ApplyAgressiveTriggerEffect();
                }
            }
        }

        public void Update()
        {
            if (this.Behavior.IsTriggered)
            {
                if (this.Behavior is Aggressive) {
                    if (this.Behavior.IsTriggered)
                    {
                        ((Aggressive) this.Behavior).IsTriggered = true;
                        this.ApplyAgressiveTriggerEffect();
                    }
                }
            }
        }

        private void AttackAffectSource(Blob source)
        {
            source.Health = source.Health - source.Health / 2;
        }

        private void AttackAffectTarget(Blob source, Blob target)
        {
            target.Respond(source.Damage * 2);
        }

        private void ApplyAgressiveTriggerEffect()
        {
            this.Damage *= 2;
        }

        private void ApplyAgressiveRecurrentEffect()
        {
            if (((Aggressive) this.Behavior).ToDelayRecurrentEffect)
            {
                ((Aggressive) this.Behavior).ToDelayRecurrentEffect = false;
            }
            else
            {
                this.Damage -= 5;

                if (this.Damage <= this.initialHealth)
                {
                    this.Damage = this.initialDamage;
                }
            }
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"IBlob {this.Name} KILLED";
            }

            return $"IBlob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}