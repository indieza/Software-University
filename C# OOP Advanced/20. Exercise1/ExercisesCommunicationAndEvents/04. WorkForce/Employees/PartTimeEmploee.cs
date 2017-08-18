public class PartTimeEmploee : BaseEmploee
{
    private const int WorkHoursPerWeek = 20;

    public PartTimeEmploee(string name) : base(name, WorkHoursPerWeek)
    {
    }
}