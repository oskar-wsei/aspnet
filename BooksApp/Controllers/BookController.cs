using BooksApp.Contracts;
using BooksApp.Resolvers;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_bookService.FindAll(new BookResolver { IncludeAuthor = true }));
    }

    [HttpGet]
    public IActionResult PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 2)
    {
        return View(_bookService.FindPage(page, size, new BookResolver { IncludeAuthor = true }));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var book = _bookService.FindById(id, new BookResolver { IncludeAuthor = true, IncludePublisher = true });
        if (book == null) return RedirectToAction("Index");
        return View(book);
    }
}