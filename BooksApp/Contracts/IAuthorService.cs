using BooksApp.Models;

namespace BooksApp.Contracts;

public interface IAuthorService
{
    int Add(Author book);
    void Delete(int id);
    void Update(Author book);
    List<Author> FindAll();
    Author? FindById(int id);
}
