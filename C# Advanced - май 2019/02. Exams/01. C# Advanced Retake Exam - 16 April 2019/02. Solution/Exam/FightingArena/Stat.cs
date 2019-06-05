namespace FightingArena
{
    public class Stat
    {
        private int strength;
        private int flexibility;
        private int agility;
        private int skills;
        private int intelligence;

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            protected set
            {
                this.strength = value;
            }
        }

        public int Flexibility
        {
            get
            {
                return this.flexibility;
            }
            protected set
            {
                this.flexibility = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            protected set
            {
                this.agility = value;
            }
        }

        public int Skills
        {
            get
            {
                return this.skills;
            }
            protected set
            {
                this.skills = value;
            }
        }

        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            protected set
            {
                this.intelligence = value;
            }
        }
    }
}