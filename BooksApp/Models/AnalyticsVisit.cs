namespace BooksApp.Models;

public class AnalyticsVisit
{
    public int? Id { get; set; }
    public string? UserAgent { get; set; }
    public DateTime? CreatedAt { get; set; }
}