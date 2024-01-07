using BooksAppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Resolvers;

public class BookResolver
{
    public bool IncludeAuthor { get; set; }
    public bool IncludePublisher { get; set; }

    public void Resolve(ref IQueryable<BookEntity> queryable)
    {
        if (IncludeAuthor) queryable = queryable.Include(book => book.Author);
        if (IncludePublisher) queryable = queryable.Include(book => book.Publisher);
    }
}