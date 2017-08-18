public class Citizen : IResident, IPerson
{
    public Citizen(string name, string country, int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }

    public string Country { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    string IPerson.GetName()
    {
        return this.Name;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }
}