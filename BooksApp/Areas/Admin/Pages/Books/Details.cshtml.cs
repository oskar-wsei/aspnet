#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using BooksApp.Resolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Books;

public class DetailsPage : PageModel
{
    public Book Book { get; set; }

    private readonly IBookService _bookService;

    public DetailsPage(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult OnGet(int id)
    {
        Book = _bookService.FindById(id, new BookResolver { IncludeAuthor = true, IncludePublisher = true });
        return Book is null ? NotFound() : Page();
    }
}