#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.Areas.Admin.Pages.Books;

[Authorize(Roles = "admin")]
public class UpdatePage : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Book Form { get; set; }

    public List<SelectListItem> Authors { get; set; }
    public List<SelectListItem> Publishers { get; set; }

    private readonly IAuthorService _authorService;
    private readonly IPublisherService _publisherService;
    private readonly IBookService _bookService;

    public UpdatePage(
        IAuthorService authorService,
        IPublisherService publisherService,
        IBookService bookService)
    {
        _authorService = authorService;
        _publisherService = publisherService;
        _bookService = bookService;
    }

    public IActionResult OnGet(int id)
    {
        Form = _bookService.FindById(id);
        if (Form is null) return NotFound();
        InitializeSelectItems();
        return Page();
    }

    public ActionResult OnPostAsync(int id)
    {
        InitializeSelectItems();
        
        if (!ModelState.IsValid) return Page();
        
        Form.Id = id;
        
        _bookService.Update(Form);
        
        return Page();
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