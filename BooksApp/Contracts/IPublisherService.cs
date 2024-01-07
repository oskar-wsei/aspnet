using BooksApp.Models;

namespace BooksApp.Contracts;

public interface IPublisherService
{
    int Add(Publisher publisher);
    void Delete(int id);
    void Update(Publisher publisher);
    List<Publisher> FindAll();
    Publisher? FindById(int id);
}