#nullable disable

using System.ComponentModel.DataAnnotations;
using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Authors;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty]
    public FormModel Form { get; set; }

    private readonly IAuthorService _authorService;

    public CreatePage(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public ActionResult OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var author = new Author
        {
            FirstName = Form.FirstName,
            LastName = Form.LastName
        };

        _authorService.Add(author);
        return RedirectToPage("Index");
    }

    public class FormModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}