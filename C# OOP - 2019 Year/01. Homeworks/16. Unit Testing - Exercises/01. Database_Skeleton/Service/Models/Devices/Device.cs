using System;
using System.Linq;
using System.Collections.Generic;

using Service.Models.Contracts;

namespace Service.Models.Devices
{
    public abstract class Device : IRepairable
    {
        private string make;
        private readonly List<IPart> parts;

        public Device(string make)
        {
            this.Make = make;

            this.parts = new List<IPart>();
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Make cannot be null or empty!");
                }

                this.make = value;
            }
        }

        public IReadOnlyCollection<IPart> Parts => this.parts;

        public virtual void AddPart(IPart part)
        {
            if (this.Parts.Where(p => p.Name == part.Name).Count() == 1)
            {
                throw new InvalidOperationException("This part already exists!");
            }

            this.parts.Add(part);
        }

        public void RemovePart(string partName)
        {
            if (String.IsNullOrEmpty(partName))
            {
                throw new ArgumentException("Part name cannot be null or empty!");
            }

            IPart partToBeRemoved = this.parts
                .FirstOrDefault(p => p.Name == partName);

            if (partToBeRemoved == null)
            {
                throw new InvalidOperationException("You cannot remove part which does not exist!");
            }

            this.parts.Remove(partToBeRemoved);
        }

        public void RepairPart(string partName)
        {
            if (String.IsNullOrEmpty(partName))
            {
                throw new ArgumentException("Part name cannot be null or empty!");
            }

            IPart partToBeRepaired = this.parts
                .FirstOrDefault(p => p.Name == partName);

            if (partToBeRepaired == null)
            {
                throw new InvalidOperationException("You cannot repair part which does not exist!");
            }

            if (!partToBeRepaired.IsBroken)
            {
                throw new InvalidOperationException("You cannot repair part which is not broken!");
            }

            partToBeRepaired.Repair();
        }
    }
}
