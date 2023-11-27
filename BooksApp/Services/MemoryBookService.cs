using BooksApp.Contracts;
using BooksApp.Models;

namespace BooksApp.Services;

public class MemoryBookService : IBookService
{
    private readonly IDateTimeProvider _timeProvider;
    private readonly Dictionary<int, Book> _books = new();

    private int _booksAutoIncrement = 1;

    public MemoryBookService(IDateTimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
        AddDefaultBooks();
    }

    public int Add(Book book)
    {
        var id = _booksAutoIncrement++;
        book.Id = id;
        book.CreatedAt = _timeProvider.GetDate();
        _books.Add(id, book);
        return id;
    }

    public void Delete(int id)
    {
        _books.Remove(id);
    }

    public List<Book> FindAll(bool includeAuthor)
    {
        return _books.Values.ToList();
    }

    public Book? FindById(int id, bool includeAuthor)
    {
        if (!_books.ContainsKey(id)) return null;
        return _books[id];
    }

    public void Update(Book book)
    {
        if (!book.Id.HasValue || !_books.ContainsKey(book.Id.Value)) return;
        var currentBook = _books[book.Id.Value];
        book.CreatedAt = currentBook.CreatedAt;
        book.UpdatedAt = _timeProvider.GetDate();
        _books[book.Id.Value] = book;
    }

    private void AddDefaultBooks()
    {
        Add(new Book
        {
            Title = "ASP.NET Core in Action",
            AuthorId = 1,
            Pages = 370,
            PublishYear = 2017
        });
        Add(new Book
        {
            Title = "Microservices in .NET",
            AuthorId = 2,
            Pages = 300,
            PublishYear = 2020
        });
        Add(new Book
        {
            Title = "Ultimate ASP.NET Core Web API",
            AuthorId = 2,
            Pages = 250,
            PublishYear = 2019
        });
    }
}
