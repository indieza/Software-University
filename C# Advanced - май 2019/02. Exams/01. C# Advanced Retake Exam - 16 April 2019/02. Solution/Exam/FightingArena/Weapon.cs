namespace FightingArena
{
    public class Weapon
    {
        private int size;
        private int solidity;
        private int sharpness;

        public Weapon(int size, int solidity, int sharpness)
        {
            this.Size = size;
            this.Solidity = solidity;
            this.Sharpness = sharpness;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            protected set
            {
                this.size = value;
            }
        }

        public int Solidity
        {
            get
            {
                return this.solidity;
            }
            protected set
            {
                this.solidity = value;
            }
        }

        public int Sharpness
        {
            get
            {
                return this.sharpness;
            }
            protected set
            {
                this.sharpness = value;
            }
        }
    }
}