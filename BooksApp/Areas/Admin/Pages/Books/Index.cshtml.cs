using BooksApp.Contracts;
using BooksApp.Models;
using BooksApp.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Books;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public List<Book> Books { get; set; }

    private readonly IBookService _bookService;

    public IndexPage(IBookService bookService)
    {
        _bookService = bookService;
    }

    public void OnGet()
    {
        Books = _bookService.FindAll(new BookResolver { IncludeAuthor = true, IncludePublisher = true });
    }
}