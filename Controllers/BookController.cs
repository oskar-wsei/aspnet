using Lab3App.Contracts;
using Lab3App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3App.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        return View(_bookService.FindAll());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        _bookService.Add(book);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var book = _bookService.FindById(id);
        if (book == null) return RedirectToAction("Index");
        return View(book);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var book = _bookService.FindById(id);
        if (book == null) return RedirectToAction("Index");
        return View(book);
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
}