using BooksApp.Contracts;

namespace BooksApp.Middlewares;

public class PageListMiddleware : IMiddleware
{
    private readonly IPageService _pageService;

    public PageListMiddleware(IPageService pageService)
    {
        _pageService = pageService;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var pageList = _pageService.FindList();
        context.Items.Add("PageList", pageList);
        await next(context);
    }
}