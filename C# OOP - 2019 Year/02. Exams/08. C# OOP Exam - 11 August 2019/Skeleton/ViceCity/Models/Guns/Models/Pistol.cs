namespace ViceCity.Models.Guns.Models
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;

        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 1 <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return 1;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return 1;
            }

            return 0;
        }
    }
}