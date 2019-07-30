namespace Service.Models.Parts
{
    public class PhonePart : Part
    {
        private const decimal multiplier = 1.3m;

        public PhonePart(string name, decimal cost)
            : base(name, cost * multiplier, false)
        {

        }

        public PhonePart(string name, decimal cost, bool isBroken) 
            : base(name, cost * multiplier, isBroken)
        {

        }
    }
}
