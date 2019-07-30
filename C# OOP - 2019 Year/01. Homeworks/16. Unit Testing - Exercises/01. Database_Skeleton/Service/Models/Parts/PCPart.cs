namespace Service.Models.Parts
{
    public class PCPart : Part
    {
        private const decimal multiplier = 1.2m;

        public PCPart(string name, decimal cost)
            : base (name, cost * multiplier, false)
        {
            
        }

        public PCPart(string name, decimal cost, bool isBroken) 
            : base(name, cost * multiplier, isBroken)
        {

        }
    }
}
