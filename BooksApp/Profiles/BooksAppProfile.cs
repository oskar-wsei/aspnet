using AutoMapper;
using BooksApp.Models;
using BooksApp.Pagination;
using BooksAppData.Entities;

namespace BooksApp.Profiles;

public class BooksAppProfile : Profile
{
    public BooksAppProfile()
    {
        CreateMap<BookEntity, Book>();
        CreateMap<Book, BookEntity>()
            .ForMember(entity => entity.Id, options => options.Ignore())
            .ForMember(entity => entity.UpdatedAt, options => options.Ignore())
            .ForMember(entity => entity.CreatedAt, options => options.Ignore());

        CreateMap<AuthorEntity, Author>();
        CreateMap<Author, AuthorEntity>()
            .ForMember(entity => entity.Id, options => options.Ignore());
        
        CreateMap<PublisherEntity, Publisher>();
        CreateMap<Publisher, PublisherEntity>()
            .ForMember(entity => entity.Id, options => options.Ignore());        
        
        CreateMap<PageEntity, Page>();
        CreateMap<Page, PageEntity>()
            .ForMember(entity => entity.Id, options => options.Ignore())
            .ForMember(entity => entity.UpdatedAt, options => options.Ignore())
            .ForMember(entity => entity.CreatedAt, options => options.Ignore());
        
        CreateMap<AnalyticsVisitEntity, AnalyticsVisit>();
        CreateMap<AnalyticsVisit, AnalyticsVisitEntity>()
            .ForMember(entity => entity.Id, options => options.Ignore());
    }
}