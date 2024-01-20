#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Books;

[Authorize(Roles = "admin")]
public class CreateApiPage : PageModel
{
    [BindProperty]
    public Book Form { get; set; }
    
    private readonly IBookService _bookService;

    public CreateApiPage(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public ActionResult OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var book = new Book
        {
            Title = Form.Title,
            Pages = Form.Pages,
            ISBN = Form.ISBN,
            PublishYear = Form.PublishYear,
            AuthorId = Form.AuthorId,
            PublisherId = Form.PublisherId
        };

        _bookService.Add(book);
        return RedirectToPage("Index");
    }
}