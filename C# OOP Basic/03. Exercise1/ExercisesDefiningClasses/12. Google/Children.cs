public class Children
{
    private string childrenName;
    private string childrenBirthday;

    public Children(string childrenName, string childrenBirthday)
    {
        this.childrenName = childrenName;
        this.childrenBirthday = childrenBirthday;
    }

    public string ChildrenName
    {
        get { return this.childrenName; }
        set { this.childrenName = value; }
    }

    public string ChildrenBirthday
    {
        get { return this.childrenBirthday; }
        set { this.childrenBirthday = value; }
    }

    public override string ToString()
    {
        return $"{this.childrenName} {this.childrenBirthday}";
    }
}