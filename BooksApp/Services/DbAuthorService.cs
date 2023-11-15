using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;
using BooksAppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Services;

public class DbAuthorService : IAuthorService
{
    private readonly AppDbContext _dbContext;

    public DbAuthorService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
    }

    public int Add(Author book)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<AuthorEntity> FindAll()
    {
        return _dbContext.Authors.ToList();
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
