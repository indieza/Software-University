public class Kitten : Cat
{
    public override string ProduceSound()
    {
        return "Miau";
    }

    public Kitten(string name, int age, string gender) : base(name, age, "Female")
    {
    }
}