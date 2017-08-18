using System.Collections.Generic;

public class WeeklyCalendar
{
    private List<WeeklyEntry> weeklySchedule;

    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }

    public List<WeeklyEntry> WeeklySchedule
    {
        get { return this.weeklySchedule; }
        set { this.weeklySchedule = value; }
    }

    public void AddEntry(string weekday, string notes)
    {
        this.weeklySchedule.Add(new WeeklyEntry(weekday, notes));
    }
}