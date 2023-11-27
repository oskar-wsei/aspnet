using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAppData.Entities;

[Table("authors")]
public class AuthorEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }

    [Required]
    [Column("first_name")]
    public string? FirstName { get; set; }

    [Required]
    [Column("last_name")]
    public string? LastName { get; set; }

    public ISet<BookEntity> Books { get; set; }
    
    public string? FullName =>
        FirstName is null ? LastName : LastName is not null ? $"{FirstName} {LastName}" : FirstName;
}
