public class Dog : Animal
{
    public override string ProduceSound()
    {
        return "BauBau";
    }

    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }
}