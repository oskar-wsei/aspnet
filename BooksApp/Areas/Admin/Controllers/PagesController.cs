using BooksApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class PagesController : Controller
{
    private readonly IPageService _pageService;

    public PagesController(IPageService pageService)
    {
        _pageService = pageService;
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _pageService.Delete(id);
        return Redirect("/Admin/pages");
    }
}