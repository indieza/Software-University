namespace TrafficLights
{
    public class GreenLight : Color
    {
        public GreenLight(string name)
            : base(name)
        {
        }

        public override string ChangeColor()
        {
            this.Name = "Yellow";
            return "Yellow";
        }
    }
}