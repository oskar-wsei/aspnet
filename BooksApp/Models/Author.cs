namespace BooksApp.Models;

public class Author
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public ISet<Book> Books { get; set; }

    public string? FullName =>
        FirstName is null ? LastName : LastName is not null ? $"{FirstName} {LastName}" : FirstName;
}
