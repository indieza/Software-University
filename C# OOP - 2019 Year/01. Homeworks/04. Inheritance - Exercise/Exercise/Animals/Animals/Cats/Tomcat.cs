namespace Animals
{
    using Animals.Genders;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, CatsGender.Male.ToString())
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}