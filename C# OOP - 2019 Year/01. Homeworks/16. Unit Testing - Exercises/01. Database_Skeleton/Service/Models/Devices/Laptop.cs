using System;

using Service.Models.Contracts;
using Service.Models.Parts;

namespace Service.Models.Devices
{
    public class Laptop : Device
    {
        public Laptop(string make) : base(make)
        {
        }

        public override void AddPart(IPart part)
        {
            if (part.GetType() != typeof(LaptopPart))
            {
                throw new InvalidOperationException($"You cannot add {part.GetType().Name} to {this.GetType().Name}!");
            }

            base.AddPart(part);
        }
    }
}
