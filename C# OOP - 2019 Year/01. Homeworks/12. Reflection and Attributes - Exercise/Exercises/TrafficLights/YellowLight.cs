namespace TrafficLights
{
    public class YellowLight : Color
    {
        public YellowLight(string name)
            : base(name)
        {
        }

        public override string ChangeColor()
        {
            this.Name = "Red";
            return "Red";
        }
    }
}