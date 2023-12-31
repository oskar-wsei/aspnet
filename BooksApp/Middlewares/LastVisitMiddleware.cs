using System.Globalization;

namespace BooksApp.Middlewares;

public class LastVisitMiddleware : IMiddleware
{
    public const string CookieName = "BooksAppLastVisit";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var lastVisitDate = GetLastVisitDateFromCookie(context.Request.Cookies);
        context.Items.Add(CookieName, lastVisitDate);
        context.Response.Cookies.Append(CookieName, DateTime.Now.ToString(CultureInfo.InvariantCulture));
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