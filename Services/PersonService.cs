using CPC.Data;
using CPC.Interfaces;
using static System.Enum;

namespace CPC.Services;

public class PersonService : IPersonService
{
    public Person CreatePerson(string frequency, DateTime? selectedDate, List<DayOfWeek> daysOfWeek, string name)
    {
        var dateTime = selectedDate ?? DateTime.Today;

        TryParse(frequency, out Frequency Frequency);

        var person = new Person
        {
            NotificationDates = new List<DateTime?>(),
            NotificationDays = new List<DayOfWeek>(),
            Name = name
        };

        switch (Frequency)
        {
            case Frequency.Daily:
            {
                for (var i = 0; i < 90; i++) person.NotificationDates.Add(dateTime.AddDays(i));
                break;
            }
            case Frequency.Weekly:
            {
                for (var i = 0; i < 90; i += 7) person.NotificationDates.Add(dateTime.AddDays(i));
                break;
            }
            case Frequency.Monthly:
            {
                for (var i = 0; i < 3; i++) person.NotificationDates.Add(dateTime.AddMonths(i));
                break;
            }
            case Frequency.SpecificDays:
            {
                for (var i = 0; i < 90; i++)
                    if (daysOfWeek.Contains(dateTime.AddDays(i).DayOfWeek))
                        person.NotificationDates.Add(dateTime.AddDays(i));
                break;
            }
            case Frequency.Never:
            default:
                return person;
        }

        return person;
    }
}