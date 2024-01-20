using BooksAppData.Entities;

namespace BooksApp.Resolvers;

public class AnalyticsVisitResolver
{
    public DateTime? DateFrom { get; set; }

    public void Resolve(ref IQueryable<AnalyticsVisitEntity> queryable)
    {
        if (DateFrom is not null) queryable = queryable.Where(visit => visit.CreatedAt >= DateFrom);
    }
}