using CPC.Data;

namespace CPC.Interfaces;

public interface IPersonService
{
    public Person CreatePerson(string frequency, DateTime? selectedDate, string name);

}