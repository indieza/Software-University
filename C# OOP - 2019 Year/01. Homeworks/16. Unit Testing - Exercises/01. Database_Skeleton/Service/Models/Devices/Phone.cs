using System;

using Service.Models.Contracts;
using Service.Models.Parts;

namespace Service.Models.Devices
{
    public class Phone : Device
    {
        public Phone(string make) : base(make)
        {

        }

        public override void AddPart(IPart part)
        {
            if (part.GetType() != typeof(PhonePart))
            {
                throw new InvalidOperationException($"You cannot add {part.GetType().Name} to {this.GetType().Name}!");
            }

            base.AddPart(part);
        }
    }
}
