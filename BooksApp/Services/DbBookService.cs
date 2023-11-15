using BooksApp.Contracts;
using BooksApp.Mappers;
using BooksApp.Models;
using BooksAppData;

namespace BooksApp.Services;

public class DbBookService : IBookService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public DbBookService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    public int Add(Book book)
    {
        book.CreatedAt = _dateTimeProvider.GetDate();
        var entry = _dbContext.Books.Add(BookMapper.ToEntity(book));
        _dbContext.SaveChanges();
        return entry.Entity.Id ?? 0;
    }

    public void Delete(int id)
    {
        var book = _dbContext.Books.Find(id);
        if (book is null) return;
        _dbContext.Remove(book);
        _dbContext.SaveChanges();
    }

    public List<Book> FindAll()
    {
        return _dbContext.Books.Select(entity => BookMapper.FromEntity(entity)).ToList();
    }

    public Book? FindById(int id)
    {
        var entity = _dbContext.Books.Find(id);
        if (entity is null) return null;
        return BookMapper.FromEntity(entity);
    }

    public void Update(Book book)
    {
        var previousBook = _dbContext.Books.Find(book.Id);
        if (previousBook is null) return;
        book.CreatedAt = previousBook.CreatedAt;
        book.UpdatedAt = _dateTimeProvider.GetDate();
        var entity = BookMapper.ToEntity(book);
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
}
