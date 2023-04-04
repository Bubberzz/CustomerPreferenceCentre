namespace CPC.Data;

public class Person
{
    public string Name { get; set; }
    public List<DateTime?> NotificationDates { get; set; }
    public List<DayOfWeek> NotificationDays { get; set; }
}