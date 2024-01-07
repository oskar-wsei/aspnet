namespace BooksApp.Models;

public class Publisher
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    
    public ISet<Book> Books { get; set; }
}