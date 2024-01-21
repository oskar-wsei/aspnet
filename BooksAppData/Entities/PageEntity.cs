using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAppData.Entities;

[Table("pages")]
public class PageEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }

    [Required]
    [Column("slug")]
    public string? Slug { get; set; }
    
    [Required]
    [Column("title")]
    public string? Title { get; set; }
    
    [Column("content")]
    public string? Content { get; set; }
    
    [Required]
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}