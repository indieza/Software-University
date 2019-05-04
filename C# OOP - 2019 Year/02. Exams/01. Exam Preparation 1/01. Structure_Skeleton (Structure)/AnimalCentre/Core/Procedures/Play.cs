using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core
{
    public class Play : Procedure, IProcedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            return sb.ToString().TrimEnd();
        }
    }
}