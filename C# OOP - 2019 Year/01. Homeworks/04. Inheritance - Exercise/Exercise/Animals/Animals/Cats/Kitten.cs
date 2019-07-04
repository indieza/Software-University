namespace Animals
{
    using Animals.Genders;

    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, CatsGender.Female.ToString())
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}