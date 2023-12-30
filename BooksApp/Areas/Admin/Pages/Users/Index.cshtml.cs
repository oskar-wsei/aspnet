using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Users;

[Authorize(Roles = "admin")]
public class IndexPage : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    
    public List<IdentityUser> Users { get; set; }

    public IndexPage(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public void OnGet()
    {
        Users = _userManager.Users.ToList();
    }
}