namespace ViceCity.Models.Guns.Models
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int InitialPistolDamage = 1;

        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - InitialPistolDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return InitialPistolDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return InitialPistolDamage;
            }

            return 0;
        }
    }
}