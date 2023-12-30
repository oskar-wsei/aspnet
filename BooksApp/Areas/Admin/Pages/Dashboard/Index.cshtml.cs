using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Dashboard;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public void OnGet()
    {

    }
}