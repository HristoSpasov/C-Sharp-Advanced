using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private string weekday;
    private string notes;

    public WeeklyEntry(string weekday, string notes)
    {
        this.weekday = weekday;
        this.notes = notes;
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekdayComparison = string.Compare(this.weekday, other.weekday, StringComparison.InvariantCulture);
        if (weekdayComparison != 0) return weekdayComparison;
        return string.Compare(this.notes, other.notes, StringComparison.InvariantCulture);
    }

    public override string ToString()
    {
        return $"{this.weekday} - {this.notes}";
    }
}