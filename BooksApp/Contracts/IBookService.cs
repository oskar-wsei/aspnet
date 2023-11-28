using BooksApp.Models;
using BooksApp.Pagination;

namespace BooksApp.Contracts;

public interface IBookService
{
    int Add(Book book);
    void Delete(int id);
    void Update(Book book);
    List<Book> FindAll(bool includeAuthor = false);
    PagedList<Book> FindPage(int pageNumber, int pageSize, bool includeAuthor = false);
    Book? FindById(int id, bool includeAuthor = false);
}
