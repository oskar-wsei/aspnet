using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BooksApp.Contracts;

namespace BooksApp.Controllers;

public class HomeController : Controller
{
    private readonly IPageService _pageService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IPageService pageService, ILogger<HomeController> logger)
    {
        _pageService = pageService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var page = _pageService.FindBySlug("home");
        if (page is null) return NotFound();
        return View("Page", page);
    }

    [Route("/page/{slug}")]
    public IActionResult Page(string slug)
    {
        var page = _pageService.FindBySlug(slug);
        if (page is null) return NotFound();
        if (page.Slug == "home") return Redirect("Index");
        return View("Page", page);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}