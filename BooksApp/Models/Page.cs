using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Models;

public class Page
{
    [HiddenInput]
    public int? Id { get; set; }

    [StringLength(maximumLength: 512)]
    public string? Slug { get; set; }
    
    [Required]
    [StringLength(maximumLength: 512)]
    public string? Title { get; set; }
    
    [Required]
    [StringLength(maximumLength: 65536)]
    public string? Content { get; set; }
    
    [HiddenInput]
    public DateTime? CreatedAt { get; set; }

    [HiddenInput]
    public DateTime? UpdatedAt { get; set; }
}