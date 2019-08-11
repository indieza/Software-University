namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 5 <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= 5;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return 5;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= 5;
                return 5;
            }

            return 0;
        }
    }
}