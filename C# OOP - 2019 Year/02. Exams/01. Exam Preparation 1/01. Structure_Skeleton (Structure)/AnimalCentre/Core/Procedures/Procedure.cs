using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public abstract class Procedure : IProcedure
    {
        private IDictionary<string, IAnimal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new Dictionary<string, IAnimal>();
        }

        public IDictionary<string, IAnimal> ProcedureHistory
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

        public abstract string History();

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}