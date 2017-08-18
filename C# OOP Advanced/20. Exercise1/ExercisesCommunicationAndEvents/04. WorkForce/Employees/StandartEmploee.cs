public class StandartEmploee : BaseEmploee
{
    private const int WorkHoursPerWeek = 40;

    public StandartEmploee(string name) : base(name, WorkHoursPerWeek)
    {
    }
}