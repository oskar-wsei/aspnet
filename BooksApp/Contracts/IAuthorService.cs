using BooksApp.Models;

namespace BooksApp.Contracts;

public interface IAuthorService
{
    int Add(Author author);
    void Delete(int id);
    void Update(Author author);
    List<Author> FindAll();
    Author? FindById(int id);
}
