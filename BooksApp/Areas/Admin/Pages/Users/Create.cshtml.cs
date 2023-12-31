#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Areas.Admin.Pages.Users;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty]
    public FormModel Form { get; set; }

    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;

    public CreatePage(
        UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore)
    {
        _userManager = userManager;
        _userStore = userStore;
    }

    public async Task<ActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = new IdentityUser();
        await _userStore.SetUserNameAsync(user, Form.UserName, CancellationToken.None);
        await ((IUserEmailStore<IdentityUser>)_userStore).SetEmailAsync(user, Form.Email, CancellationToken.None);

        var result = await _userManager.CreateAsync(user, Form.Password);

        if (result.Succeeded) return RedirectToPage("Index");

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        
        return Page();
    }

    public class FormModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}