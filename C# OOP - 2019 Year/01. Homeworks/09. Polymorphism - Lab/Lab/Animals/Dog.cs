namespace Animals
{
    using System.Text;

    public class Dog : Animal
    {
        public Dog(string favouriteFood, string name)
            : base(favouriteFood, name)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("DJAAF");

            return sb.ToString().TrimEnd();
        }
    }
}