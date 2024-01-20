using AutoMapper;
using BooksApp.Contracts;
using BooksApp.Models;
using BooksApp.Resolvers;
using BooksAppData;
using BooksAppData.Entities;

namespace BooksApp.Services;

public class DbAnalyticsService : IAnalyticsService
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public DbAnalyticsService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }

    public int AddVisit(AnalyticsVisit visit)
    {
        var entity = _mapper.Map<AnalyticsVisitEntity>(visit);
        entity.CreatedAt = _dateTimeProvider.GetDate();
        var entry = _dbContext.AnalyticsVisits.Add(entity);
        _dbContext.SaveChanges();
        return entry.Entity.Id ?? 0;
    }

    public List<AnalyticsVisit> FindAllVisits(AnalyticsVisitResolver? resolver = null)
    {
        var query = _dbContext.AnalyticsVisits.AsQueryable();
        resolver?.Resolve(ref query);
        return _mapper.Map<List<AnalyticsVisit>>(query.ToList());
    }
}