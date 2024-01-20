#nullable disable

using System.ComponentModel.DataAnnotations;
using BooksApp.Contracts;
using BooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Publishers;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty]
    public FormModel Form { get; set; }

    private readonly IPublisherService _publisherService;

    public CreatePage(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    public ActionResult OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var publisher = new Publisher { Name = Form.Name };
        _publisherService.Add(publisher);
        return RedirectToPage("Index");
    }

    public class FormModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}