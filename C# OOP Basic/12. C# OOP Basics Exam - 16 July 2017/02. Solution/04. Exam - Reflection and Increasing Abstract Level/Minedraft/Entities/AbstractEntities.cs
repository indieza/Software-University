public abstract class AbstractEntities
{
    private string id;

    protected AbstractEntities(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
}