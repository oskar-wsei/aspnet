using BooksApp.Models;
using BooksApp.Resolvers;

namespace BooksApp.Contracts;

public interface IAnalyticsService
{
    int AddVisit(AnalyticsVisit visit);
    List<AnalyticsVisit> FindAllVisits(AnalyticsVisitResolver? resolver = null);
}