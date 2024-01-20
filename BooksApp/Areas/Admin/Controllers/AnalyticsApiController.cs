using BooksApp.Contracts;
using BooksApp.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Areas.Admin.Controllers;

[Route("admin/api/analytics")]
[Authorize(Roles = "admin")]
[ApiController]
public class AnalyticsApiController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AnalyticsApiController(IAnalyticsService analyticsService, IDateTimeProvider dateTimeProvider)
    {
        _analyticsService = analyticsService;
        _dateTimeProvider = dateTimeProvider;
    }

    [HttpGet]
    [Route("visits")]
    public IActionResult GetVisits()
    {
        var weekAgo = _dateTimeProvider.GetDate().AddDays(-7);
        var visits = _analyticsService.FindAllVisits(new AnalyticsVisitResolver { DateFrom = weekAgo });
        var lastWeekDateStrings = GenerateLastWeekDateStrings();

        var data = lastWeekDateStrings.Select(dateString => new AnalyticsEntry { Date = dateString, Count = 0 }).ToList();

        foreach (var visit in visits)
        {
            var visitDateString = visit.CreatedAt.Value.ToString("dd-MM-yyyy");
            var entry = data.First(entry => entry.Date == visitDateString);
            entry.Count++;
        }
        
        return Ok(data.Select(entry => new { entry.Date, entry.Count }).ToList());
    }

    private List<string> GenerateLastWeekDateStrings()
    {
        var dateStrings = new List<string>();

        for (var daysToAdd = -7; daysToAdd <= 0; daysToAdd++)
        {
            var date = _dateTimeProvider.GetDate().AddDays(daysToAdd);
            dateStrings.Add(date.ToString("dd-MM-yyyy"));
        }

        return dateStrings;
    }

    private class AnalyticsEntry
    {
        public string Date { get; set; }
        public int Count { get; set; }
    }
}