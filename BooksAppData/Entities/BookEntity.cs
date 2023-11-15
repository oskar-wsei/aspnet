using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAppData.Entities;

[Table("books")]
public class BookEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }

    [Required]
    [Column("title")]
    public string? Title { get; set; }

    [Required]
    [Column("author_id")]
    public int? AuthorId { get; set; }

    public AuthorEntity? Author { get; set; }

    [Required]
    [Column("pages")]
    public int? Pages { get; set; }

    [Column("isbn")]
    public string? ISBN { get; set; }

    [Column("publish_year")]
    public int? PublishYear { get; set; }

    [Column("publisher")]
    public string? Publisher { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
