using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAppData.Entities;

[Table("analytics_visits")]
public class AnalyticsVisitEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    
    [Column("user_agent")]
    public string? UserAgent { get; set; }
    
    [Required]
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
}
