public class Citizen : ICitizen
{
    private string name;
    private int age;
    private string id;
    private string birthday;

    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
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

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string Birthday
    {
        get { return this.birthday; }
        set { this.birthday = value; }
    }
}