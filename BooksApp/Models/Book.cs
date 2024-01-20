using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models;

public class Book
{
    [HiddenInput]
    public int? Id { get; set; }

    [Required]
    [StringLength(maximumLength: 1024)]
    public string? Title { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int? Pages { get; set; }

    [StringLength(maximumLength: 64)]
    [RegularExpression("^[0-9-]+$")]
    public string? ISBN { get; set; }

    [Display(Name = "Publish Year")]
    [Range(0, int.MaxValue)]
    public int? PublishYear { get; set; }

    [Display(Name = "Author")]
    [HiddenInput]
    public int? AuthorId { get; set; }

    [HiddenInput]
    public Author? Author { get; set; }

    [Display(Name = "Publisher")]
    [HiddenInput]
    public int? PublisherId { get; set; }

    [HiddenInput]
    public Publisher? Publisher { get; set; }

    [HiddenInput]
    public DateTime? CreatedAt { get; set; }

    [HiddenInput]
    public DateTime? UpdatedAt { get; set; }
}