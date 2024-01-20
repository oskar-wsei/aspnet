using BooksApp.Contracts;
using BooksApp.Models;

namespace BooksApp.Middlewares;

public class AnalyticsMiddleware : IMiddleware
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsMiddleware(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!IsAdminRoute(context))
        {
            _analyticsService.AddVisit(new AnalyticsVisit { UserAgent = context.Request.Headers.UserAgent });
        }
        await next(context);
    }

    private static bool IsAdminRoute(HttpContext context)
    {
        return context.Request.Path.StartsWithSegments("/admin", StringComparison.OrdinalIgnoreCase);
    }
}