namespace FightingArena
{
    public class Stat
    {
        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Flexibility { get; set; }

        public int Agility { get; set; }

        public int Skills { get; set; }

        public int Intelligence { get; set; }
    }
}
