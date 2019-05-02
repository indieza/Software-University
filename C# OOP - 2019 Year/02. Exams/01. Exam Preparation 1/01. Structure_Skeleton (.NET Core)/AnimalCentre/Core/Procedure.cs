using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Procedure : IProcedure
    {
        private ICollection<IAnimal> procedureHistory;

        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public ICollection<IAnimal> ProcedureHistory
        {
            get
            {
                return this.procedureHistory;
            }
            private set
            {
                this.procedureHistory = value;
            }
        }
    }
}