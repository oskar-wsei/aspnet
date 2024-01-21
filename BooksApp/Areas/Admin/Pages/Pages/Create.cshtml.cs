#nullable disable

using BooksApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Page = BooksApp.Models.Page;

namespace BooksApp.Areas.Admin.Pages.Pages;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty]
    public Page Form { get; set; }

    private readonly IPageService _pageService;

    public CreatePage(IPageService pageService)
    {
        _pageService = pageService;
    }

    public ActionResult OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        
        int id = _pageService.Add(Form);
        return RedirectToPage("Update", new { id });
    }
}