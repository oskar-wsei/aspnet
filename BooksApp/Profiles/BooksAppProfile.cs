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
        
        CreateMap<AuthorEntity, Author>().ReverseMap();
        CreateMap<PublisherEntity, Publisher>().ReverseMap();
    }
}