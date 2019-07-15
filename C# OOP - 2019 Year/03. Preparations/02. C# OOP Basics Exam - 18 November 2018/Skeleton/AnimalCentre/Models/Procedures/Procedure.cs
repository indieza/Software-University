namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Constraints;
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public IReadOnlyCollection<IAnimal> ProcedureHistory => this.procedureHistory.AsReadOnly();

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in this.procedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        protected void CheckTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;
            }
            else
            {
                throw new ArgumentException(ExceptionsMessages.NotEnoughtTimeForProcedure);
            }
        }
    }
}