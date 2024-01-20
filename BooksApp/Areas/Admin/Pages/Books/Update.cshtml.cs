#nullable disable

using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;
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
    private readonly AppDbContext _dbContext;

    public UpdatePage(
        IAuthorService authorService,
        IPublisherService publisherService,
        IBookService bookService,
        AppDbContext dbContext)
    {
        _authorService = authorService;
        _publisherService = publisherService;
        _bookService = bookService;
        _dbContext = dbContext;
    }

    public IActionResult OnGet(int id)
    {
        Form = _bookService.FindById(id);
        if (Form is null) return NotFound();
        InitializeSelectItems();
        return Page();
    }

    public ActionResult OnPost(int id)
    {
        InitializeSelectItems();
        
        if (!ModelState.IsValid) return Page();
        
        // TODO: Find out why EF breaks foreign keys when AutoMapper patches existing entity
        // Form.Id = id;
        // _bookService.Update(Form);
        
        var entity = _dbContext.Books.Find(id);
        if (entity is null) return NotFound();

        entity.Title = Form.Title;
        entity.AuthorId = Form.AuthorId;
        entity.PublisherId = Form.PublisherId;
        entity.PublishYear = Form.PublishYear;
        entity.ISBN = Form.ISBN;
        entity.Pages = Form.Pages;

        _dbContext.Books.Update(entity);
        _dbContext.SaveChanges();

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