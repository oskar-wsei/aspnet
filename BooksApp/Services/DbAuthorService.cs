using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;

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
    
    public int Add(Author book)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Author> FindAll()
    {
        return _mapper.Map<List<Author>>(_dbContext.Authors.ToList());
    }

    public Author? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Author book)
    {
        throw new NotImplementedException();
    }
}
