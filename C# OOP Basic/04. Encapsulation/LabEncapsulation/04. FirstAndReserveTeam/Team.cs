using System.Collections.Generic;

public class Team
{
    private string teamName;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string teamName)
    {
        this.teamName = teamName;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public string TeamName
    {
        get { return this.teamName; }
        set { this.teamName = value; }
    }

    public IReadOnlyList<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly(); }
    }

    public IReadOnlyList<Person> ReserveTeam
    {
        get { return this.reserveTeam.AsReadOnly(); }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reserveTeam.Add(person);
        }
    }
}