using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekday, string notes)
    {
        this.Weekday = weekday;
        this.Notes = notes;
    }

    public string Weekday { get; set; }

    public string Notes { get; set; }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var weekdayComparison = string.Compare(this.Weekday, other.Weekday, StringComparison.Ordinal);

        if (weekdayComparison != 0)
        {
            return weekdayComparison;
        }

        return string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Notes}";
    }
}