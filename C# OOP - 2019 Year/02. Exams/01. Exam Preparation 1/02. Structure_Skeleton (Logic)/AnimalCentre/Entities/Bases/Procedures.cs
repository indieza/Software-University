using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Entities
{
    public abstract class Procedures : IProcedure
    {
        private ICollection<IAnimal> procedureHistory;

        protected Procedures()
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

        public abstract void DoService(IAnimal animal, int procedureTime);

        public abstract string History();
    }
}