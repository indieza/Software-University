namespace _04.TheCommandsStrikeBack.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    internal class UnitRepository : IRepository
    {
        private readonly IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                StringBuilder statBuilder = new StringBuilder();
                foreach (var entry in this.amountOfUnits)
                {
                    string formatedEntry = $"{entry.Key} -> {entry.Value}";
                    statBuilder.AppendLine(formatedEntry);
                }

                return statBuilder.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            string unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (this.amountOfUnits.ContainsKey(unitType) && this.amountOfUnits[unitType] > 0)
            {
                this.amountOfUnits[unitType]--;
            }
            else
            {
                throw new InvalidOperationException("No such units in repository.");
            }
        }
    }
}