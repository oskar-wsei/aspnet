#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Authors;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public List<Author> Authors { get; set; }

    private readonly IAuthorService _authorService;

    public IndexPage(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public void OnGet()
    {
        Authors = _authorService.FindAll();
    }
}