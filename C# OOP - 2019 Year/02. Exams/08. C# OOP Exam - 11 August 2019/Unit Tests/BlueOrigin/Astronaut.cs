namespace BlueOrigin
{
    public class Astronaut
    {
        public Astronaut(string name, double oxygenInPercentage)
        {
            this.Name = name;
            this.OxygenInPercentage = oxygenInPercentage;
        }

        public string Name { get; }

        public double OxygenInPercentage { get; }
    }
}