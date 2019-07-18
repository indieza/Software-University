namespace TrafficLights
{
    public class RedLight : Color
    {
        public RedLight(string name)
            : base(name)
        {
        }

        public override string ChangeColor()
        {
            this.Name = "Green";
            return "Green";
        }
    }
}