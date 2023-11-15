using BooksApp.Models;
using BooksAppData.Entities;

namespace BooksApp.Contracts;

public interface IAuthorService
{
    int Add(Author book);
    void Delete(int id);
    void Update(Author book);
    List<AuthorEntity> FindAll();
    Author? FindById(int id);
}
