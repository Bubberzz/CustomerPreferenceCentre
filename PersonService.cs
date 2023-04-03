using CPC.Data;
using static System.Enum;

namespace CPC;

public class PersonService : IPersonService
{
    public Person CreatePerson(string frequency, DateTime? selectedDate, string name)
    {
        var dateTime = selectedDate ?? DateTime.Today;

        TryParse(frequency, out Frequency Frequency);

        var person = new Person
        {
            Preferences = new List<DateTime?>(),
            Name = name
        };
        
        switch (Frequency)
        {
            case Frequency.Daily:
            {
                for (var i = 0; i < 90; i++)
                {
                    person.Preferences.Add(dateTime.AddDays(i));
                }
                break;
            }
            case Frequency.Weekly:
            {
                for (var i = 0; i < 90; i+=7)
                {
                    person.Preferences.Add(dateTime.AddDays(i));
                }
                break;
            }
            case Frequency.Monthly:
            {
                for (var i = 0; i < 3; i++)
                {
                    person.Preferences.Add(dateTime.AddMonths(i));
                }
                break;
            }
            default:
                return person;
        }

        return person;
    }
}

public interface IPersonService
{
    public Person CreatePerson(string frequency, DateTime? selectedDate, string name);
}