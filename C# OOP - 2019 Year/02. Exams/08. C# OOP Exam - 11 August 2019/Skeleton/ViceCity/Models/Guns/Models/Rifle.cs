namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialRifelDamage = 5;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - InitialRifelDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= InitialRifelDamage;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return InitialRifelDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= InitialRifelDamage;
                return InitialRifelDamage;
            }

            return 0;
        }
    }
}