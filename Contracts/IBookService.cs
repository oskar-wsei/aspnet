using Lab3App.Models;

namespace Lab3App.Contracts;

public interface IBookService
{
    int Add(Book book);
    void Delete(int id);
    void Update(Book book);
    List<Book> FindAll();
    Book? FindById(int id);
}
