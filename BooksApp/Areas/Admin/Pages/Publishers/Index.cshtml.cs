#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Publishers;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public List<Publisher> Publishers { get; set; }

    private readonly IPublisherService _publisherService;

    public IndexPage(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    public void OnGet()
    {
        Publishers = _publisherService.FindAll();
    }
}