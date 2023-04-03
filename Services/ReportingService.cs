using CPC.Data;
using CPC.Interfaces;

namespace CPC.Services;

public class ReportingService : IReportingService
{
    public string GenerateReport(List<Person> people)
    {
        var reportList = new List<string>();
        var date = DateTime.Today;
        string _report = null;

        for (var i = 0; i < 90; i++)
        {
            var day = date.AddDays(i).ToString("dd/MM/yyyy");

            foreach (var person in people)
            {
                var a = person.Preferences.Find(x => x.Value == date.AddDays(i));
                if (a is not null)
                {
                    day += $@" {person.Name}";
                }
            }

            reportList.Add(day);

            _report = string.Join("\n", reportList.ToArray());
        }

        return _report;
    }
}