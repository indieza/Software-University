public class Cat : Animal
{
    public override string ProduceSound()
    {
        return "MiauMiau";
    }

    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }
}