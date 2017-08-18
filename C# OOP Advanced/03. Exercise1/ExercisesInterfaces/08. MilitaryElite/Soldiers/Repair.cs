namespace MilitaryElite.Entities
{
    public class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public string Name { get; private set; }

        public int Hours { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.Hours}";
        }
    }
}