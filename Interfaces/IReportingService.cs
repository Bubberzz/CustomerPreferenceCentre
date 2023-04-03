using CPC.Data;

namespace CPC.Interfaces;

public interface IReportingService
{
    public string GenerateReport(List<Person> people);

}