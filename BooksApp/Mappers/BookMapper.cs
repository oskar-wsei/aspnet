using BooksApp.Models;
using BooksAppData.Entities;

namespace BooksApp.Mappers;

public class BookMapper
{
    public static Book FromEntity(BookEntity entity)
    {
        return new Book()
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            Pages = entity.Pages,
            ISBN = entity.ISBN,
            PublishYear = entity.PublishYear,
            Publisher = entity.Publisher,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }

    public static BookEntity ToEntity(Book model)
    {
        return new BookEntity()
        {
            Id = model.Id,
            Title = model.Title,
            Author = model.Author,
            Pages = model.Pages,
            ISBN = model.ISBN,
            PublishYear = model.PublishYear,
            Publisher = model.Publisher,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
