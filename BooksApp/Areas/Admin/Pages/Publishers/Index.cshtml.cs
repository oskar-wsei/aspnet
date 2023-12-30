using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Publishers;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    public void OnGet()
    {
        
    }
}