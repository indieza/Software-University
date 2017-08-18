public class Rebel : IRebel, IBuyer
{
    private string name;
    private int age;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Group
    {
        get { return this.group; }
        set { this.group = value; }
    }

    public int Food
    {
        get { return this.food; }
        set { this.food = value; }
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}