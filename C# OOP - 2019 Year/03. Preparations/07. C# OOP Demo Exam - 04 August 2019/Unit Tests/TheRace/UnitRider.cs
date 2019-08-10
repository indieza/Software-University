namespace TheRace
{
    using System;

    public class UnitRider
    {
        private string name;

        public UnitRider(string name, UnitMotorcycle motorcycle)
        {
            this.Name = name;
            this.Motorcycle = motorcycle;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value ?? throw new ArgumentNullException(nameof(Name), "Name cannot be null!");
            }
        }

        public UnitMotorcycle Motorcycle { get; }
    }
}