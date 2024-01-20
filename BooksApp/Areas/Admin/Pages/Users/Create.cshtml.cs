#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.Areas.Admin.Pages.Users;

[Authorize(Roles = "admin")]
public class CreatePage : PageModel
{
    [BindProperty(SupportsGet = true)]
    public FormModel Form { get; set; }
    
    public List<SelectListItem> Roles { get; set; }

    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreatePage(
        UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _userStore = userStore;
        _roleManager = roleManager;
    }

    public void OnGet()
    {
        InitializeRoleSelectItems();
    }

    public async Task<ActionResult> OnPostAsync()
    {
        InitializeRoleSelectItems();
        
        if (!ModelState.IsValid) return Page();

        var user = new IdentityUser();
        await _userStore.SetUserNameAsync(user, Form.UserName, CancellationToken.None);
        await ((IUserEmailStore<IdentityUser>)_userStore).SetEmailAsync(user, Form.Email, CancellationToken.None);

        var result = await _userManager.CreateAsync(user, Form.Password);

        if (!HandleIdentityResultErrors(result)) return Page();
        
        result = await _userManager.AddToRoleAsync(user, Form.Role);
        
        if (!HandleIdentityResultErrors(result)) return Page();
        
        return RedirectToPage("Index");
    }

    private void InitializeRoleSelectItems()
    {
        Roles = _roleManager.Roles.Select(role => new SelectListItem
        {
            Text = role.Name,
            Value = role.Name,
            Selected = role.Name == Form.Role
        }).ToList();
    }

    private bool HandleIdentityResultErrors(IdentityResult result)
    {
        if (result.Succeeded) return true;
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return false;
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

        [Display(Name = "Role")]
        public string Role { get; set; } = "user";
    }
}