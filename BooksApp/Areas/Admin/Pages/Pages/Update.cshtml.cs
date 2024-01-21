#nullable disable

using BooksApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Page = BooksApp.Models.Page;

namespace BooksApp.Areas.Admin.Pages.Pages;

[Authorize(Roles = "admin")]
public class UpdatePage : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Page Form { get; set; }

    private readonly IPageService _pageService;

    public UpdatePage(IPageService pageService)
    {
        _pageService = pageService;
    }

    public IActionResult OnGet(int id)
    {
        Form = _pageService.FindById(id);
        if (Form is null) return NotFound();
        return Page();
    }

    public ActionResult OnPost(int id)
    {
        if (!ModelState.IsValid) return Page();
        Form.Id = id;
        _pageService.Update(Form);
        return RedirectToPage("Update");
    }
}