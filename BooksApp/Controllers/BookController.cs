using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public BookController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    public IActionResult Index()
    {
        return View(_bookService.FindAll(includeAuthor: true));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(ApplyBookAuthorsSelectListItems(new Book()));
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid) return View(ApplyBookAuthorsSelectListItems(book));
        _bookService.Add(book);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var book = _bookService.FindById(id, includeAuthor: true);
        if (book == null) return RedirectToAction("Index");
        return View(book);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var book = _bookService.FindById(id);
        if (book == null) return RedirectToAction("Index");
        return View(ApplyBookAuthorsSelectListItems(book));
    }

    [HttpPost]
    public IActionResult Update(Book book)
    {
        if (!book.Id.HasValue) return RedirectToAction("Index");
        _bookService.Update(book);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return RedirectToAction("Index");
    }

    private Book ApplyBookAuthorsSelectListItems(Book book)
    {
        book.Authors = _authorService.FindAll().Select(author => new SelectListItem
        {
            Value = author.Id.ToString(),
            Text = author.FullName,
            Selected = book.AuthorId == author.Id
        }).ToList();

        return book;
    }
}