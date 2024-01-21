using BooksApp.Models;
using BooksApp.Pagination;
using BooksApp.Resolvers;

namespace BooksApp.Contracts;

public interface IPageService
{
    int Add(Page page);
    void Delete(int id);
    void Update(Page page);
    List<Page> FindAll();
    List<Page> FindList();
    Page? FindById(int id);
    Page? FindBySlug(string slug);
}
