#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.Areas.Admin.Pages.Books;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Book Form { get; set; }

    public List<SelectListItem> Authors { get; set; }
    public List<SelectListItem> Publishers { get; set; }

    private readonly IAuthorService _authorService;
    private readonly IPublisherService _publisherService;
    private readonly IBookService _bookService;

    public CreatePage(
        IAuthorService authorService,
        IPublisherService publisherService,
        IBookService bookService)
    {
        _authorService = authorService;
        _publisherService = publisherService;
        _bookService = bookService;
    }

    public void OnGet()
    {
        InitializeSelectItems();
    }

    public ActionResult OnPostAsync()
    {
        InitializeSelectItems();

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

    private void InitializeSelectItems()
    {
        InitializeAuthorsSelectItems();
        InitializePublishersSelectItems();
    }

    private void InitializeAuthorsSelectItems()
    {
        Authors = _authorService.FindAll().Select(author => new SelectListItem
        {
            Text = author.FullName,
            Value = author.Id.ToString(),
            Selected = author.Id == Form.AuthorId
        }).ToList();
    }

    private void InitializePublishersSelectItems()
    {
        Publishers = _publisherService.FindAll().Select(publisher => new SelectListItem
        {
            Text = publisher.Name,
            Value = publisher.Id.ToString(),
            Selected = publisher.Id == Form.PublisherId
        }).ToList();
    }
}