using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;
using BooksAppData.Entities;

namespace BooksApp.Services;

public class DbAuthorService : IAuthorService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public DbAuthorService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }
    
    public int Add(Author author)
    {
        var entity = _mapper.Map<AuthorEntity>(author);
        var entry = _dbContext.Authors.Add(entity);
        _dbContext.SaveChanges();
        return entry.Entity.Id ?? 0;
    }

    public void Delete(int id)
    {
        var author = _dbContext.Authors.Find(id);
        if (author is null) return;
        _dbContext.Remove(author);
        _dbContext.SaveChanges();
    }

    public List<Author> FindAll()
    {
        return _mapper.Map<List<Author>>(_dbContext.Authors.ToList());
    }

    public Author? FindById(int id)
    {
        var query = _dbContext.Authors.AsQueryable();
        var entity = query.FirstOrDefault(b => b.Id == id);
        return entity is null ? null : _mapper.Map<Author>(entity);
    }

    public void Update(Author author)
    {
        var entity = _dbContext.Authors.Find(author.Id);
        if (entity is null) return;
        _mapper.Map(author, entity);
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
}
