namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;

            set
            {
                base.Age = value;
            }
        }
    }
}