namespace TrafficLights
{
    public abstract class Color
    {
        protected Color(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        public abstract string ChangeColor();
    }
}