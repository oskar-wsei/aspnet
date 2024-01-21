using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksAppData;
using BooksAppData.Entities;
using Slugify;

namespace BooksApp.Services;

public class DbPageService : IPageService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public DbPageService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }
    
    public int Add(Page page)
    {
        var entity = _mapper.Map<PageEntity>(page);
        entity.Slug = new SlugHelper().GenerateSlug(entity.Slug ?? entity.Title);
        entity.CreatedAt = _dateTimeProvider.GetDate();
        var entry = _dbContext.Pages.Add(entity);
        _dbContext.SaveChanges();
        return entry.Entity.Id ?? 0;
    }

    public void Delete(int id)
    {
        var page = _dbContext.Pages.Find(id);
        if (page is null) return;
        _dbContext.Remove(page);
        _dbContext.SaveChanges();
    }

    public void Update(Page page)
    {
        var entity = _dbContext.Pages.Find(page.Id);
        if (entity is null) return;
        _mapper.Map(page, entity);
        entity.Slug = new SlugHelper().GenerateSlug(entity.Slug ?? entity.Title);
        entity.UpdatedAt = _dateTimeProvider.GetDate();
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<Page> FindAll()
    {
        var query = _dbContext.Pages.AsQueryable();
        return _mapper.Map<List<Page>>(query.ToList());
    }

    public List<Page> FindList()
    {
        var query = _dbContext.Pages.Select(entity => new PageEntity
        {
            Id = entity.Id,
            Title = entity.Title,
            Slug = entity.Slug
        });
        return _mapper.Map<List<Page>>(query.ToList());
    }

    public Page? FindById(int id)
    {
        var query = _dbContext.Pages.AsQueryable();
        var entity = query.FirstOrDefault(b => b.Id == id);
        return entity is null ? null : _mapper.Map<Page>(entity);
    }

    public Page? FindBySlug(string slug)
    {
        var query = _dbContext.Pages.AsQueryable();
        var entity = query.FirstOrDefault(b => b.Slug == slug);
        return entity is null ? null : _mapper.Map<Page>(entity);
    }
}