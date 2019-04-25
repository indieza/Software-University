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
            private set
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
            private set
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
            private set
            {
                this.sharpness = value;
            }
        }
    }
}