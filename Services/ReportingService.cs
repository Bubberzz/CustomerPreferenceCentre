using CPC.Data;
using CPC.Interfaces;

namespace CPC.Services;

public class ReportingService : IReportingService
{
    public string GenerateReport(List<Person> people)
    {
        var reportList = new List<string>();
        var date = DateTime.Today;
        var report = "";

        for (var i = 0; i < 90; i++)
        {
            var day = date.AddDays(i).ToString("dd/MM/yyyy");

            day = (from person in people
                let a = person.NotificationDates.Find(x => x.Value == date.AddDays(i))
                where a is not null
                select person).Aggregate(day, (current, person) => current + $@" {person.Name}");

            reportList.Add(day);

            report = string.Join("\n", reportList.ToArray());
        }

        return report;
    }
}