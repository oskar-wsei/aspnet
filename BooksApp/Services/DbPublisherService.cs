using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;
using BooksAppData.Entities;

namespace BooksApp.Services;

public class DbPublisherService : IPublisherService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;
    
    public DbPublisherService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }
    
    public int Add(Publisher publisher)
    {
        var entity = _mapper.Map<PublisherEntity>(publisher);
        var entry = _dbContext.Publishers.Add(entity);
        _dbContext.SaveChanges();
        return entry.Entity.Id ?? 0;
    }

    public void Delete(int id)
    {
        var publisher = _dbContext.Publishers.Find(id);
        if (publisher is null) return;
        _dbContext.Remove(publisher);
        _dbContext.SaveChanges();
    }

    public void Update(Publisher publisher)
    {
        var entity = _dbContext.Publishers.Find(publisher.Id);
        if (entity is null) return;
        _mapper.Map(publisher, entity);
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<Publisher> FindAll()
    {
        return _mapper.Map<List<Publisher>>(_dbContext.Publishers.ToList());
    }

    public Publisher? FindById(int id)
    {
        var query = _dbContext.Publishers.AsQueryable();
        var entity = query.FirstOrDefault(b => b.Id == id);
        return entity is null ? null : _mapper.Map<Publisher>(entity);
    }
}