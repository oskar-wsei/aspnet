using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksApp.Pagination;
using BooksAppData;
using BooksAppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Services;

public class DbBookService : IBookService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public DbBookService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }

    public int Add(Book book)
    {
        var entity = _mapper.Map<BookEntity>(book);
        entity.CreatedAt = _dateTimeProvider.GetDate();
        var entry = _dbContext.Books.Add(entity);
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

    public List<Book> FindAll(bool includeAuthor)
    {
        var query = _dbContext.Books.AsQueryable();
        if (includeAuthor) query = query.Include(book => book.Author);
        return _mapper.Map<List<Book>>(query.ToList());
    }

    public PagedList<Book> FindPage(int pageNumber, int pageSize, bool includeAuthor)
    {
        var totalCount = _dbContext.Books.Count();
        var query = _dbContext.Books.AsQueryable()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        if (includeAuthor) query = query.Include(book => book.Author);

        return new PagedList<Book>(
            query.ToList().Select(entity => _mapper.Map<Book>(entity)), totalCount, pageNumber, pageSize
        );
    }

    public Book? FindById(int id, bool includeAuthor)
    {
        var query = _dbContext.Books.AsQueryable();
        if (includeAuthor) query = query.Include(book => book.Author);
        var entity = query.FirstOrDefault(b => b.Id == id);
        return entity is null ? null : _mapper.Map<Book>(entity);
    }

    public void Update(Book book)
    {
        var entity = _dbContext.Books.Find(book.Id);
        if (entity is null) return;
        _mapper.Map(book, entity);
        entity.UpdatedAt = _dateTimeProvider.GetDate();
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
}