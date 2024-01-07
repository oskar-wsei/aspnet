using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAppData.Entities;

[Table("publishers")]
public class PublisherEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }
        
    [Required]
    [Column("name")]
    public string? Name { get; set; }
    
    public ISet<BookEntity> Books { get; set; }
}