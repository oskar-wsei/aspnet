using BooksApp.Models;
using BooksApp.Pagination;
using BooksApp.Resolvers;

namespace BooksApp.Contracts;

public interface IBookService
{
    int Add(Book book);
    void Delete(int id);
    void Update(Book book);
    List<Book> FindAll(BookResolver? resolver = null);
    PagedList<Book> FindPage(int pageNumber, int pageSize, BookResolver? resolver = null);
    Book? FindById(int id, BookResolver? resolver = null);
}
