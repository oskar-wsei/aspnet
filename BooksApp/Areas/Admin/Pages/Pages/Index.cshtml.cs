using BooksApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Page = BooksApp.Models.Page;

namespace BooksApp.Areas.Admin.Pages.Pages;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public List<Page> Pages { get; set; }

    private readonly IPageService _pageService;

    public IndexPage(IPageService pageService)
    {
        _pageService = pageService;
    }

    public void OnGet()
    {
        Pages = _pageService.FindAll();
    }
}