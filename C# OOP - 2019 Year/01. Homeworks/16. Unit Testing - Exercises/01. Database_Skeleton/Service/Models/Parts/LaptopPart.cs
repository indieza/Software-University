namespace Service.Models.Parts
{
    public class LaptopPart : Part
    {
        private const decimal multiplier = 1.5m;

        public LaptopPart(string name, decimal cost)
            : base (name, cost * multiplier, false)
        {
            
        }
        public LaptopPart(string name, decimal cost, bool isBroken) : base(name, cost * multiplier, isBroken)
        {

        }
    }
}
