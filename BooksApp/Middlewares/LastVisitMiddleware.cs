using System.Globalization;
using BooksApp.Contracts;

namespace BooksApp.Middlewares;

public class LastVisitMiddleware : IMiddleware
{
    public const string CookieName = "BooksAppLastVisit";
    
    private readonly IDateTimeProvider _dateTimeProvider;

    public LastVisitMiddleware(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var lastVisitDate = GetLastVisitDateFromCookie(context.Request.Cookies);
        context.Items.Add(CookieName, lastVisitDate);
        context.Response.Cookies.Append(CookieName, _dateTimeProvider.GetDate().ToString(CultureInfo.InvariantCulture));
        await next(context);
    }

    private static DateTime? GetLastVisitDateFromCookie(IRequestCookieCollection cookies)
    {
        if (!cookies.ContainsKey(CookieName)) return null;
        var lastVisitDateString = cookies[CookieName];
        if (lastVisitDateString is null) return null;

        try
        {
            return DateTime.Parse(lastVisitDateString, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}