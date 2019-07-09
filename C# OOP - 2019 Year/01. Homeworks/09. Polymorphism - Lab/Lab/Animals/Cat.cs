namespace Animals
{
    using System.Text;

    public class Cat : Animal
    {
        public Cat(string favouriteFood, string name)
            : base(favouriteFood, name)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("MEEOW");

            return sb.ToString().TrimEnd();
        }
    }
}